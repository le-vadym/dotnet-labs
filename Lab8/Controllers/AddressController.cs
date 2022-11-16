using Lab8.Models;
using Lab8.Repositories;

namespace Lab8.Server.Controllers;

public class AddressController : GenericController<Address>
{
    public AddressController(IRepository<Address> repository) : base(repository) { }
}
