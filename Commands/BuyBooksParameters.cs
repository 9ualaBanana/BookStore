using BookStore.Services;

namespace BookStore.Commands;

[CommandLine.Verb("buy", HelpText = "Buy a book by its ID.")]
public record BuyBooksParameters
{
    [CommandLine.Option("id", Required = true, HelpText = "The ID of the book to buy.")]
    public int Id { get; init; }
}

static partial class BookStoreServiceCommandHandlers
{

    internal static async Task<int> HandleCommandAsync(this BookStoreService service, BuyBooksParameters opts)
    {
        if (await service.BuyBookAsync(opts.Id))
            Console.WriteLine("Book purchased successfully.");
        else
            Console.WriteLine("Book not available or out of stock.");

        return 0;
    }
}
