using BookStore.Services;

namespace BookStore.Commands;

[CommandLine.Verb("get", HelpText = "Retrieve books with optional filters.")]
public record GetBooksParameters
{
    internal const string DateTimeFormat = "yyyy-MM-dd";

    [CommandLine.Option('t', "title", HelpText = "Filter books by title.")]
    public string? Title { get; init; }

    [CommandLine.Option('a', "author", HelpText = "Filter books by author.")]
    public string? Author { get; init; }

    [CommandLine.Option('d', "date", HelpText = "Filter books by publication date.", MetaValue = DateTimeFormat)]
    public string? Date { get; init; }

    [CommandLine.Option('o', "order-by", Default = "id", HelpText = "Sort books by key.", MetaValue = "[id|title|author|date|count]")]
    public string? OrderBy { get; init; }
}

static partial class BookStoreServiceCommandHandlers
{
    internal static async Task<int> HandleCommandAsync(this BookStoreService service, GetBooksParameters opts)
    {
        DateTime? parsedDate = null;
        if (!string.IsNullOrEmpty(opts.Date))
        {
            if (!DateTime.TryParseExact(opts.Date, GetBooksParameters.DateTimeFormat, null, System.Globalization.DateTimeStyles.None, out var validDate))
            {
                Console.WriteLine($"Invalid date format. Please use {GetBooksParameters.DateTimeFormat}.");
                return 1;
            }
            parsedDate = validDate;
        }

        var books = await service.GetBooksAsync(opts.Title, opts.Author, parsedDate, opts.OrderBy);
        if (books.Any())
            foreach (var book in books)
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Date: {book.PublicationDate:yyyy-MM-dd}, Quantity: {book.Quantity}");
        else
            Console.WriteLine("No books found matching the criteria.");

        return 0;
    }
}
