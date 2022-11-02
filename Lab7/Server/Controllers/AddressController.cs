using Lab7.Models;
using Lab7.Repositories;

namespace Lab7.Server.Controllers;

public class AddressController : GenericController<Address>
{
    public AddressController(IRepository<Address> repository) : base(repository) { }
}
