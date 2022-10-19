using Lab4.Models;
using Lab4.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab4.Controllers;

public sealed class ReadersController : GenericController<Reader>
{
    private readonly IRepository<Address> _addressRepository;

    public ReadersController(IRepository<Reader> repository, IRepository<Address> addressRepository) : base(repository)
    {
        _addressRepository = addressRepository;
    }

    public override async Task<IActionResult> Create()
    {
        var addresses = await _addressRepository.GetAllAsync();

        ViewBag.Addresses = new SelectList(addresses, "Id", "Description");

        return await base.Create();
    }

    public override async Task<IActionResult> Edit(Guid? id)
    {
        var addresses = await _addressRepository.GetAllAsync();

        ViewBag.Addresses = new SelectList(addresses, "Id", "Description");

        return await base.Edit(id);
    }
}
