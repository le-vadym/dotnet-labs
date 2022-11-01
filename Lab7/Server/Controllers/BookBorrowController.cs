using Lab7.Models;
using Lab7.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab7.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookBorrowController : GenericController<BookBorrow>
{
    public BookBorrowController(IRepository<BookBorrow> repository) : base(repository) { }
}
