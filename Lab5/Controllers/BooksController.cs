using Lab5.Models;
using Lab5.Repositories;

namespace Lab5.Controllers;

public sealed class BooksController : GenericController<Book>
{
    public BooksController(IRepository<Book> repository) : base(repository) { }
}
