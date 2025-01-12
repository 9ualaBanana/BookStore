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
