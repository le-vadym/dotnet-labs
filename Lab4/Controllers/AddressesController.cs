using Lab4.Models;
using Lab4.Repositories;

namespace Lab4.Controllers;

public sealed class AddressesController : GenericController<Address>
{
    public AddressesController(IRepository<Address> repository) : base(repository) { }
}
