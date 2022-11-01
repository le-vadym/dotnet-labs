using Lab7.Models;
using Lab7.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lab7.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : GenericController<Book>
{
    public BookController(IRepository<Book> repository) : base(repository) { }
}
