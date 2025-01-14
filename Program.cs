using CommandLine;
using BookStore.Commands;
using BookStore.Data;
using BookStore.Services;

var bookStoreService = await BookStoreService.InitializeAsync(BookStoreContext.DefaultOptions);

await CommandLine.Parser.Default
    .ParseArguments<GetBooksParameters, BuyBooksParameters, RestockBooksParameters>(args)
    .MapResult(
        async (GetBooksParameters parameters) => await bookStoreService.HandleGetCommandAsync(parameters),
        async (BuyBooksParameters parameters) => await bookStoreService.HandleBuyCommandAsync(parameters),
        async (RestockBooksParameters parameters) => await bookStoreService.HandleRestockCommandAsync(parameters),
        HandleErrorsAsync
    );

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
static async Task<int> HandleErrorsAsync(IEnumerable<Error> errors)
{
    if (HandleDefaultOptions()) return 0;

    foreach (var error in errors)
        Console.WriteLine(error.ToString());

    return 1;


    bool HandleDefaultOptions() => errors.SingleOrDefault() is Error defaultOption
        && defaultOption.Tag switch
        {
            ErrorType.HelpRequestedError or ErrorType.HelpVerbRequestedError or ErrorType.VersionRequestedError => true,
            _ => false
        };
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
