using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using Microsoft.EntityFrameworkCore.Design;
using BookStore.Services;
using Microsoft.Extensions.Configuration;

namespace BookStore.Data;

public class BookStoreContext(DbContextOptions<BookStoreContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; } = default!;

    internal static DbContextOptions<BookStoreContext> DefaultOptions
        => new DbContextOptionsBuilder<BookStoreContext>()
        .UseNpgsql(Configuration.Instance.GetConnectionString("Default"))
        .Options;

    public class Factory : IDesignTimeDbContextFactory<BookStoreContext>
    {
        public BookStoreContext CreateDbContext(string[] args) => new(DefaultOptions);
    }
}
