namespace Lab2.Models;

internal sealed class Book
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Author { get; set; } = null!;
    public decimal Price { get; set; }
}
