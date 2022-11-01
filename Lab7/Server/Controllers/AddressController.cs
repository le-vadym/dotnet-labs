using Lab7.Models;
using Lab7.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lab7.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : GenericController<Address>
{
    public AddressController(IRepository<Address> repository) : base(repository) { }
}
