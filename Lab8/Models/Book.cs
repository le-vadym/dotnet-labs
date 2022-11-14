namespace Lab8.Models;

public sealed class Book : ModelBase
{
    public string Name { get; set; } = null!;
    public string Author { get; set; } = null!;
    public decimal Price { get; set; }

    public string Description => $"{Name}, {Author}";
}
