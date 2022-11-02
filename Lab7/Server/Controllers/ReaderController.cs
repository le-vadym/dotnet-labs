using Lab7.Models;
using Lab7.Repositories;

namespace Lab7.Server.Controllers;

public class ReaderController : GenericController<Reader>
{
    public ReaderController(IRepository<Reader> repository) : base(repository) { }
}
