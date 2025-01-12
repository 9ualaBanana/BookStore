using BookStore.Services;

namespace BookStore.Commands;

static class BooksCommandsHandler
{
    internal static async Task<int> HandleGetCommandAsync(this BookStoreService service, GetBooksParameters opts)
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

    internal static async Task<int> HandleBuyCommandAsync(this BookStoreService service, BuyBooksParameters opts)
    {
        if (await service.BuyBookAsync(opts.Id))
            Console.WriteLine("Book purchased successfully.");
        else
            Console.WriteLine("Book not available or out of stock.");

        return 0;
    }

    internal static async Task<int> HandleRestockCommandAsync(this BookStoreService service, RestockBooksParameters opts)
    {
        await service.RestockBooksAsync(opts.Id, opts.Count);
        Console.WriteLine("Books restocked successfully.");

        return 0;
    }
}
