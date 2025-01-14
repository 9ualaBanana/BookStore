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
        async errors =>
        {
            if (HandleDefaultOptions()) return await Task.FromResult(0);
            else
            {
                foreach (var error in errors)
                    Console.WriteLine(error.ToString());

                return await Task.FromResult(1);
            }


            bool HandleDefaultOptions()
                => errors.SingleOrDefault() is Error defaultOption && defaultOption.Tag switch
                {
                    ErrorType.HelpRequestedError or ErrorType.HelpVerbRequestedError or ErrorType.VersionRequestedError => true,
                    _ => false
                };
        }
    );
