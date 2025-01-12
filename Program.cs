using CommandLine;
using Microsoft.EntityFrameworkCore;
using BookStore.Commands;
using BookStore.Data;
using BookStore.Services;

var options = new DbContextOptionsBuilder<BookStoreContext>()
    .UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=bookstore")
    .Options;

using (var context = new BookStoreContext(options))
    await context.Database.EnsureCreatedAsync();

var service = new BookStoreService(options);

await CommandLine.Parser.Default
    .ParseArguments<GetBooksParameters, BuyBooksParameters, RestockBooksParameters>(args)
    .MapResult(
        async (GetBooksParameters parameters) => await service.HandleGetCommandAsync(parameters),
        async (BuyBooksParameters parameters) => await service.HandleBuyCommandAsync(parameters),
        async (RestockBooksParameters parameters) => await service.HandleRestockCommandAsync(parameters),
        async errors =>
        {
            foreach (var error in errors)
                Console.WriteLine(error.ToString());

            return await Task.FromResult(1);
        }
    );
