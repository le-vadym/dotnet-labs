using Lab7.Models;
using Lab7.Repositories;

namespace Lab7.Server.Controllers;

public class BookBorrowController : GenericController<BookBorrow>
{
    public BookBorrowController(IRepository<BookBorrow> repository) : base(repository) { }
}
