using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Data;

public class BookStoreContext(DbContextOptions<BookStoreContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Author = "Author1", Title = "Book1", PublicationDate = DateTime.Parse("2020-01-01").ToUniversalTime(), Quantity = 5 },
            new Book { Id = 2, Author = "Author2", Title = "Book2", PublicationDate = DateTime.Parse("2021-06-15").ToUniversalTime(), Quantity = 3 },
            new Book { Id = 3, Author = "Author3", Title = "Book3", PublicationDate = DateTime.Parse("2019-11-20").ToUniversalTime(), Quantity = 7 }
        );
    }
}

