using Lab8.Models;
using Lab8.Repositories;

namespace Lab8.Server.Controllers;

public class BookController : GenericController<Book>
{
    public BookController(IRepository<Book> repository) : base(repository) { }
}
