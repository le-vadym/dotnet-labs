using Lab8.Models;
using Lab8.Repositories;

namespace Lab8.Server.Controllers;

public class BookBorrowController : GenericController<BookBorrow>
{
    public BookBorrowController(IRepository<BookBorrow> repository) : base(repository) { }
}
