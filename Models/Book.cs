namespace BookStore.Models;

public class Book
{
    public int Id { get; set; }
    public string Author { get; set; } = default!;
    public string Title { get; set; } = default!;
    public DateTime PublicationDate { get; set; }
    public int Quantity { get; set; }
}
