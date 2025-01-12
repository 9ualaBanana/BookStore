using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services;

internal class BookStoreService(DbContextOptions<BookStoreContext> contextOptions)
{
    public async Task<IEnumerable<Book>> GetBooksAsync(string? title = null, string? author = null, DateTime? date = null, string? orderBy = null)
    {
        using var context = new BookStoreContext(contextOptions);
        var query = context.Books.AsQueryable();

        if (!string.IsNullOrEmpty(title))
            query = query.Where(b => EF.Functions.ILike(b.Title, $"%{title}%"));
        if (!string.IsNullOrEmpty(author))
            query = query.Where(b => EF.Functions.ILike(b.Author, $"%{author}%"));
        if (date.HasValue)
            query = query.Where(b => b.PublicationDate.Date == date.Value.Date);

        query = orderBy switch
        {
            "title" => query.OrderBy(b => b.Title),
            "author" => query.OrderBy(b => b.Author),
            "date" => query.OrderBy(b => b.PublicationDate),
            "count" => query.OrderBy(b => b.Quantity),
            _ => query.OrderBy(b => b.Id),
        };

        return await query.ToListAsync();
    }

    public async Task<bool> BuyBookAsync(int id)
    {
        using var context = new BookStoreContext(contextOptions);
        if (await context.Books.FindAsync(id) is Book book && book.Quantity > 0)
        {
            book.Quantity--;
            await context.SaveChangesAsync();
            return true;
        }
        else return false;
    }

    public async Task RestockBooksAsync(int? id = null, int? count = null)
    {
        using var context = new BookStoreContext(contextOptions);
        var random = new Random();

        if (id.HasValue)
        {
            if (await context.Books.FindAsync(id.Value) is Book book)
                book.Quantity += count ?? random.Next(1, 10);
        }
        else
        {
            foreach (var book in await context.Books.ToListAsync())
                book.Quantity += count ?? random.Next(1, 10);
        }
        await context.SaveChangesAsync();
    }
}
