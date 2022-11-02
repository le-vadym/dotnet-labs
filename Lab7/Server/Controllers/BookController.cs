using Lab7.Models;
using Lab7.Repositories;

namespace Lab7.Server.Controllers;

public class BookController : GenericController<Book>
{
    public BookController(IRepository<Book> repository) : base(repository) { }
}
