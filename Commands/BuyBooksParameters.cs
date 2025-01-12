namespace BookStore.Commands;

[CommandLine.Verb("buy", HelpText = "Buy a book by its ID.")]
public record BuyBooksParameters
{
    [CommandLine.Option("id", Required = true, HelpText = "The ID of the book to buy.")]
    public int Id { get; init; }
}
