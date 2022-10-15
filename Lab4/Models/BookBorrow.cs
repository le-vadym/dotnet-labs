namespace Lab4.Models;

public sealed class BookBorrow : ModelBase
{
    public Reader Reader { get; set; } = null!;
    public Book Book { get; set; } = null!;

    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
