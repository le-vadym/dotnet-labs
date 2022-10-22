using Lab5.Models;
using Lab5.Repositories;

namespace Lab5.Controllers;

public sealed class AddressesController : GenericController<Address>
{
    public AddressesController(IRepository<Address> repository) : base(repository) { }
}
