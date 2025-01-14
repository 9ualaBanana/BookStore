using BookStore.Services;

namespace BookStore.Commands;

[CommandLine.Verb("restock", HelpText = "Restock books.")]
public record RestockBooksParameters
{
    [CommandLine.Option("id", HelpText = "The ID of the book to restock.")]
    public int? Id { get; init; }

    [CommandLine.Option("count", HelpText = "The number of books to add.")]
    public int? Count { get; init; }
}

static partial class BookStoreServiceCommandHandlers
{
    internal static async Task<int> HandleCommandAsync(this BookStoreService service, RestockBooksParameters opts)
    {
        await service.RestockBooksAsync(opts.Id, opts.Count);
        Console.WriteLine("Books restocked successfully.");

        return 0;
    }
}
