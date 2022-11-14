using Lab8.Models;
using Lab8.Repositories;

namespace Lab8.Server.Controllers;

public class ReaderController : GenericController<Reader>
{
    public ReaderController(IRepository<Reader> repository) : base(repository) { }
}
