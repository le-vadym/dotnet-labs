namespace Lab6.Models;

public sealed class BookBorrow : ModelBase
{
    public Guid ReaderId { get; set; }
    public Reader Reader { get; set; } = null!;
    public Guid BookId { get; set; }
    public Book Book { get; set; } = null!;

    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
