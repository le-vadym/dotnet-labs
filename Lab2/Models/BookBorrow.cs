namespace Lab2.Models;

internal sealed class BookBorrow
{
    public Guid Id { get; set; }
    public Reader Reader { get; set; } = null!;
    public Book Book { get; set; } = null!;

    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
