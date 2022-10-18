using Lab4.Models;
using Lab4.Repositories;

namespace Lab4.Controllers;

public class BooksController : GenericController<Book>
{
    public BooksController(IRepository<Book> repository) : base(repository) { }
}
