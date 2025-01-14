using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Polly;

namespace BookStore.Services;

internal class BookStoreService
{
    readonly DbContextOptions<BookStoreContext> contextOptions;

    BookStoreService(DbContextOptions<BookStoreContext> contextOptions)
    {
        this.contextOptions = contextOptions;
    }

    internal static async Task<BookStoreService> InitializeAsync(DbContextOptions<BookStoreContext> contextOptions)
    {
        var service = new BookStoreService(contextOptions);
        using var context = new BookStoreContext(contextOptions);
        await context.Database.MigrateAsync();
        if (!context.Books.Any())
            await service.SeedAsync();
        return service;
    }
    public async Task<IEnumerable<Book>> GetBooksAsync(string? title = null, string? author = null, DateTime? date = null, string? orderBy = null)
    {
        using var context = new BookStoreContext(contextOptions);
        var query = context.Books.AsQueryable();

        if (!string.IsNullOrEmpty(title))
            query = query.Where(b => EF.Functions.ILike(b.Title, $"%{title}%"));
        if (!string.IsNullOrEmpty(author))
            query = query.Where(b => EF.Functions.ILike(b.Author, $"%{author}%"));
        if (date.HasValue)
            query = query.Where(b => b.PublicationDate.Date == date.Value.Date);

        query = orderBy switch
        {
            "title" => query.OrderBy(b => b.Title),
            "author" => query.OrderBy(b => b.Author),
            "date" => query.OrderBy(b => b.PublicationDate),
            "count" => query.OrderBy(b => b.Quantity),
            _ => query.OrderBy(b => b.Id),
        };

        return await query.ToListAsync();
    }

    public async Task<bool> BuyBookAsync(int id)
    {
        using var context = new BookStoreContext(contextOptions);
        if (await context.Books.FindAsync(id) is Book book && book.Quantity > 0)
        {
            book.Quantity--;
            await context.SaveChangesAsync();
            return true;
        }
        else return false;
    }

    public async Task RestockBooksAsync(int? id = null, int? count = null)
    {
        using var context = new BookStoreContext(contextOptions);
        var random = new Random();

        if (id.HasValue)
        {
            if (await context.Books.FindAsync(id.Value) is Book book)
                book.Quantity += count ?? random.Next(1, 10);
        }
        else
        {
            foreach (var book in await context.Books.ToListAsync())
                book.Quantity += count ?? random.Next(1, 10);
        }
        await context.SaveChangesAsync();
    }

    internal async Task SeedAsync()
    {
        using var context = new BookStoreContext(contextOptions);
        switch (Configuration.Instance["SeedStrategy"])
        {
            case "remote":
                try
                { await SeedFromGoogleBooksAsync(); }
                catch
                { await SeedFromLocalStaticDataAsync(); }
                break;
            default:
                await SeedFromLocalStaticDataAsync();
                break;
        }
        await context.SaveChangesAsync();


        async Task SeedFromGoogleBooksAsync()
        {
            using var httpClient = new HttpClient();
            const int maxResults = 40;
            int totalBooksFetched = 0;

            var retryPolicy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            var circuitBreakerPolicy = Policy
                .Handle<HttpRequestException>()
                .CircuitBreakerAsync(2, TimeSpan.FromSeconds(15));

            var policyWrap = Policy.WrapAsync(retryPolicy, circuitBreakerPolicy);

            for (int startIndex = 0; ; startIndex += maxResults)
            {
                var url = $"https://www.googleapis.com/books/v1/volumes?q=startIndex={startIndex}&maxResults={maxResults}";

                var response = await policyWrap.ExecuteAsync(async () => await httpClient.GetStringAsync(url));
                var books = JObject.Parse(response)["items"];

                if (books == null || !books.Any())
                    break;

                foreach (var book in books)
                {
                    var volumeInfo = book["volumeInfo"];
                    if (volumeInfo == null) continue;

                    var title = volumeInfo["title"]?.ToString();
                    var authors = volumeInfo["authors"]?.FirstOrDefault()?.ToString();
                    var publishedDate = volumeInfo["publishedDate"]?.ToString();
                    if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(authors) || string.IsNullOrEmpty(publishedDate))
                        continue;

                    if (!DateTime.TryParse(publishedDate, out var publicationDate))
                        publicationDate = DateTime.UtcNow;

                    context.Books.Add(new Book
                    {
                        Title = title,
                        Author = authors,
                        PublicationDate = publicationDate.ToUniversalTime(),
                        Quantity = new Random().Next(1, 20)
                    });

                    totalBooksFetched++;
                    if (totalBooksFetched >= 40) break;
                }
            }
            await context.SaveChangesAsync();
            Console.WriteLine($"Seeded {totalBooksFetched} books from Google Books API.");
        }

        async Task SeedFromLocalStaticDataAsync()
        {
            await context.Books.AddRangeAsync([
                new Book { Id = 1, Author = "George Orwell", Title = "1984", PublicationDate = DateTime.Parse("1949-06-08").ToUniversalTime(), Quantity = 5 },
                new Book { Id = 2, Author = "J.K. Rowling", Title = "Harry Potter and the Sorcerer's Stone", PublicationDate = DateTime.Parse("1997-06-26").ToUniversalTime(), Quantity = 7 },
                new Book { Id = 3, Author = "J.R.R. Tolkien", Title = "The Hobbit", PublicationDate = DateTime.Parse("1937-09-21").ToUniversalTime(), Quantity = 3 },
                new Book { Id = 4, Author = "Harper Lee", Title = "To Kill a Mockingbird", PublicationDate = DateTime.Parse("1960-07-11").ToUniversalTime(), Quantity = 8 },
                new Book { Id = 5, Author = "F. Scott Fitzgerald", Title = "The Great Gatsby", PublicationDate = DateTime.Parse("1925-04-10").ToUniversalTime(), Quantity = 2 },
                new Book { Id = 6, Author = "Jane Austen", Title = "Pride and Prejudice", PublicationDate = DateTime.Parse("1813-01-28").ToUniversalTime(), Quantity = 6 },
                new Book { Id = 7, Author = "Markus Zusak", Title = "The Book Thief", PublicationDate = DateTime.Parse("2005-03-14").ToUniversalTime(), Quantity = 4 },
                new Book { Id = 8, Author = "Gabriel Garcia Marquez", Title = "One Hundred Years of Solitude", PublicationDate = DateTime.Parse("1967-05-30").ToUniversalTime(), Quantity = 9 },
                new Book { Id = 9, Author = "Herman Melville", Title = "Moby Dick", PublicationDate = DateTime.Parse("1851-10-18").ToUniversalTime(), Quantity = 1 },
                new Book { Id = 10, Author = "Leo Tolstoy", Title = "War and Peace", PublicationDate = DateTime.Parse("1869-01-01").ToUniversalTime(), Quantity = 7 },
                new Book { Id = 11, Author = "Ernest Hemingway", Title = "The Old Man and the Sea", PublicationDate = DateTime.Parse("1952-09-01").ToUniversalTime(), Quantity = 3 },
                new Book { Id = 12, Author = "Charles Dickens", Title = "Great Expectations", PublicationDate = DateTime.Parse("1861-01-13").ToUniversalTime(), Quantity = 5 },
                new Book { Id = 13, Author = "Virginia Woolf", Title = "Jane Eyre", PublicationDate = DateTime.Parse("1847-10-16").ToUniversalTime(), Quantity = 4 },
                new Book { Id = 14, Author = "Franz Kafka", Title = "The Metamorphosis", PublicationDate = DateTime.Parse("1915-12-19").ToUniversalTime(), Quantity = 6 },
                new Book { Id = 15, Author = "John Steinbeck", Title = "Of Mice and Men", PublicationDate = DateTime.Parse("1937-02-06").ToUniversalTime(), Quantity = 2 },
                new Book { Id = 16, Author = "Oscar Wilde", Title = "The Picture of Dorian Gray", PublicationDate = DateTime.Parse("1890-05-12").ToUniversalTime(), Quantity = 8 },
                new Book { Id = 17, Author = "Agatha Christie", Title = "Murder on the Orient Express", PublicationDate = DateTime.Parse("1934-11-20").ToUniversalTime(), Quantity = 7 },
                new Book { Id = 18, Author = "Arthur Conan Doyle", Title = "A Study in Scarlet", PublicationDate = DateTime.Parse("1887-03-01").ToUniversalTime(), Quantity = 5 },
                new Book { Id = 19, Author = "Emily Bronte", Title = "Wuthering Heights", PublicationDate = DateTime.Parse("1847-12-24").ToUniversalTime(), Quantity = 3 },
                new Book { Id = 20, Author = "Charlotte Bronte", Title = "Jane Eyre", PublicationDate = DateTime.Parse("1847-10-16").ToUniversalTime(), Quantity = 6 },
                new Book { Id = 21, Author = "George Orwell", Title = "1984", PublicationDate = DateTime.Parse("1949-06-08").ToUniversalTime(), Quantity = 4 },
                new Book { Id = 22, Author = "J.K. Rowling", Title = "Harry Potter and the Chamber of Secrets", PublicationDate = DateTime.Parse("1998-07-02").ToUniversalTime(), Quantity = 9 },
                new Book { Id = 23, Author = "J.R.R. Tolkien", Title = "The Fellowship of the Ring", PublicationDate = DateTime.Parse("1954-07-29").ToUniversalTime(), Quantity = 2 },
                new Book { Id = 24, Author = "Harper Lee", Title = "To Kill a Mockingbird", PublicationDate = DateTime.Parse("1960-07-11").ToUniversalTime(), Quantity = 8 },
                new Book { Id = 25, Author = "F. Scott Fitzgerald", Title = "Tender is the Night", PublicationDate = DateTime.Parse("1934-04-12").ToUniversalTime(), Quantity = 1 },
                new Book { Id = 26, Author = "Jane Austen", Title = "Sense and Sensibility", PublicationDate = DateTime.Parse("1811-10-30").ToUniversalTime(), Quantity = 7 },
                new Book { Id = 27, Author = "Markus Zusak", Title = "The Messenger", PublicationDate = DateTime.Parse("2002-08-01").ToUniversalTime(), Quantity = 3 },
                new Book { Id = 28, Author = "Gabriel Garcia Marquez", Title = "Chronicle of a Death Foretold", PublicationDate = DateTime.Parse("1981-05-19").ToUniversalTime(), Quantity = 5 },
                new Book { Id = 29, Author = "Herman Melville", Title = "Billy Budd, Sailor", PublicationDate = DateTime.Parse("1924-10-12").ToUniversalTime(), Quantity = 4 },
                new Book { Id = 30, Author = "Leo Tolstoy", Title = "Anna Karenina", PublicationDate = DateTime.Parse("1878-04-01").ToUniversalTime(), Quantity = 6 },
                new Book { Id = 31, Author = "Ernest Hemingway", Title = "A Farewell to Arms", PublicationDate = DateTime.Parse("1929-09-27").ToUniversalTime(), Quantity = 2 },
                new Book { Id = 32, Author = "Charles Dickens", Title = "Oliver Twist", PublicationDate = DateTime.Parse("1839-01-16").ToUniversalTime(), Quantity = 8 },
                new Book { Id = 33, Author = "Virginia Woolf", Title = "To the Lighthouse", PublicationDate = DateTime.Parse("1927-05-05").ToUniversalTime(), Quantity = 7 },
                new Book { Id = 34, Author = "Franz Kafka", Title = "The Trial", PublicationDate = DateTime.Parse("1925-08-15").ToUniversalTime(), Quantity = 1 },
                new Book { Id = 35, Author = "John Steinbeck", Title = "The Grapes of Wrath", PublicationDate = DateTime.Parse("1939-04-14").ToUniversalTime(), Quantity = 9 },
                new Book { Id = 36, Author = "Oscar Wilde", Title = "The Happy Prince and Other Stories", PublicationDate = DateTime.Parse("1888-12-20").ToUniversalTime(), Quantity = 3 },
                new Book { Id = 37, Author = "Agatha Christie", Title = "The ABC Murders", PublicationDate = DateTime.Parse("1936-01-06").ToUniversalTime(), Quantity = 5 },
                new Book { Id = 38, Author = "Arthur Conan Doyle", Title = "The Hound of the Baskervilles", PublicationDate = DateTime.Parse("1902-04-01").ToUniversalTime(), Quantity = 4 },
                new Book { Id = 39, Author = "Emily Bronte", Title = "Poems by Currer, Ellis, and Acton Bell", PublicationDate = DateTime.Parse("1846-01-20").ToUniversalTime(), Quantity = 6 },
                new Book { Id = 40, Author = "Charlotte Bronte", Title = "Villette", PublicationDate = DateTime.Parse("1853-12-16").ToUniversalTime(), Quantity = 2 }
            ]);
        }
    }
}
