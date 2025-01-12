using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Data;

public class BookStoreContext(DbContextOptions<BookStoreContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var random = new Random();
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Author = "George Orwell", Title = "1984", PublicationDate = DateTime.Parse("1949-06-08").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 2, Author = "J.K. Rowling", Title = "Harry Potter and the Sorcerer's Stone", PublicationDate = DateTime.Parse("1997-06-26").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 3, Author = "J.R.R. Tolkien", Title = "The Hobbit", PublicationDate = DateTime.Parse("1937-09-21").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 4, Author = "Harper Lee", Title = "To Kill a Mockingbird", PublicationDate = DateTime.Parse("1960-07-11").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 5, Author = "F. Scott Fitzgerald", Title = "The Great Gatsby", PublicationDate = DateTime.Parse("1925-04-10").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 6, Author = "Jane Austen", Title = "Pride and Prejudice", PublicationDate = DateTime.Parse("1813-01-28").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 7, Author = "Markus Zusak", Title = "The Book Thief", PublicationDate = DateTime.Parse("2005-03-14").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 8, Author = "Gabriel Garcia Marquez", Title = "One Hundred Years of Solitude", PublicationDate = DateTime.Parse("1967-05-30").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 9, Author = "Herman Melville", Title = "Moby Dick", PublicationDate = DateTime.Parse("1851-10-18").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 10, Author = "Leo Tolstoy", Title = "War and Peace", PublicationDate = DateTime.Parse("1869-01-01").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 11, Author = "Ernest Hemingway", Title = "The Old Man and the Sea", PublicationDate = DateTime.Parse("1952-09-01").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 12, Author = "Charles Dickens", Title = "Great Expectations", PublicationDate = DateTime.Parse("1861-01-13").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 13, Author = "Virginia Woolf", Title = "Jane Eyre", PublicationDate = DateTime.Parse("1847-10-16").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 14, Author = "Franz Kafka", Title = "The Metamorphosis", PublicationDate = DateTime.Parse("1915-12-19").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 15, Author = "John Steinbeck", Title = "Of Mice and Men", PublicationDate = DateTime.Parse("1937-02-06").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 16, Author = "Oscar Wilde", Title = "The Picture of Dorian Gray", PublicationDate = DateTime.Parse("1890-05-12").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 17, Author = "Agatha Christie", Title = "Murder on the Orient Express", PublicationDate = DateTime.Parse("1934-11-20").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 18, Author = "Arthur Conan Doyle", Title = "A Study in Scarlet", PublicationDate = DateTime.Parse("1887-03-01").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 19, Author = "Emily Bronte", Title = "Wuthering Heights", PublicationDate = DateTime.Parse("1847-12-24").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 20, Author = "Charlotte Bronte", Title = "Jane Eyre", PublicationDate = DateTime.Parse("1847-10-16").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 21, Author = "George Orwell", Title = "1984", PublicationDate = DateTime.Parse("1949-06-08").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 22, Author = "J.K. Rowling", Title = "Harry Potter and the Chamber of Secrets", PublicationDate = DateTime.Parse("1998-07-02").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 23, Author = "J.R.R. Tolkien", Title = "The Fellowship of the Ring", PublicationDate = DateTime.Parse("1954-07-29").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 24, Author = "Harper Lee", Title = "To Kill a Mockingbird", PublicationDate = DateTime.Parse("1960-07-11").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 25, Author = "F. Scott Fitzgerald", Title = "Tender is the Night", PublicationDate = DateTime.Parse("1934-04-12").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 26, Author = "Jane Austen", Title = "Sense and Sensibility", PublicationDate = DateTime.Parse("1811-10-30").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 27, Author = "Markus Zusak", Title = "The Messenger", PublicationDate = DateTime.Parse("2002-08-01").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 28, Author = "Gabriel Garcia Marquez", Title = "Chronicle of a Death Foretold", PublicationDate = DateTime.Parse("1981-05-19").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 29, Author = "Herman Melville", Title = "Billy Budd, Sailor", PublicationDate = DateTime.Parse("1924-10-12").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 30, Author = "Leo Tolstoy", Title = "Anna Karenina", PublicationDate = DateTime.Parse("1878-04-01").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 31, Author = "Ernest Hemingway", Title = "A Farewell to Arms", PublicationDate = DateTime.Parse("1929-09-27").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 32, Author = "Charles Dickens", Title = "Oliver Twist", PublicationDate = DateTime.Parse("1839-01-16").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 33, Author = "Virginia Woolf", Title = "To the Lighthouse", PublicationDate = DateTime.Parse("1927-05-05").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 34, Author = "Franz Kafka", Title = "The Trial", PublicationDate = DateTime.Parse("1925-08-15").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 35, Author = "John Steinbeck", Title = "The Grapes of Wrath", PublicationDate = DateTime.Parse("1939-04-14").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 36, Author = "Oscar Wilde", Title = "The Happy Prince and Other Stories", PublicationDate = DateTime.Parse("1888-12-20").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 37, Author = "Agatha Christie", Title = "The ABC Murders", PublicationDate = DateTime.Parse("1936-01-06").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 38, Author = "Arthur Conan Doyle", Title = "The Hound of the Baskervilles", PublicationDate = DateTime.Parse("1902-04-01").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 39, Author = "Emily Bronte", Title = "Poems by Currer, Ellis, and Acton Bell", PublicationDate = DateTime.Parse("1846-01-20").ToUniversalTime(), Quantity = random.Next(1, 10) },
            new Book { Id = 40, Author = "Charlotte Bronte", Title = "Villette", PublicationDate = DateTime.Parse("1853-12-16").ToUniversalTime(), Quantity = random.Next(1, 10) }
        );
    }
}

