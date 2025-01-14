using CommandLine;
using Microsoft.EntityFrameworkCore;
using BookStore.Commands;
using BookStore.Data;
using BookStore.Services;
using Microsoft.Extensions.Configuration;

var options = new DbContextOptionsBuilder<BookStoreContext>()
    .UseNpgsql(Configuration.Instance.GetConnectionString("Default"))
    .Options;

var service = new BookStoreService(options);
using (var context = new BookStoreContext(options))
{
    await context.Database.MigrateAsync();
    if (!context.Books.Any())
        await service.SeedAsync();
}

await CommandLine.Parser.Default
    .ParseArguments<GetBooksParameters, BuyBooksParameters, RestockBooksParameters>(args)
    .MapResult(
        async (GetBooksParameters parameters) => await service.HandleGetCommandAsync(parameters),
        async (BuyBooksParameters parameters) => await service.HandleBuyCommandAsync(parameters),
        async (RestockBooksParameters parameters) => await service.HandleRestockCommandAsync(parameters),
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
