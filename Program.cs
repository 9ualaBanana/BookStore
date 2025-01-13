using CommandLine;
using Microsoft.EntityFrameworkCore;
using BookStore.Commands;
using BookStore.Data;
using BookStore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{EnvironmentName.Development}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var options = new DbContextOptionsBuilder<BookStoreContext>()
    .UseNpgsql(configuration.GetConnectionString("Default"))
    .Options;

using (var context = new BookStoreContext(options))
    if ((await context.Database.GetPendingMigrationsAsync()).Any())
        await context.Database.MigrateAsync();

var service = new BookStoreService(options);

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
