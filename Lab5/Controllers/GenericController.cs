using Lab5.Models;
using Lab5.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

public class GenericController<T> : Controller where T : ModelBase
{
    private readonly IRepository<T> _repository;

    public GenericController(IRepository<T> repository)
    {
        _repository = repository;
    }

    public virtual async Task<IActionResult> Index()
    {
        return View(await _repository.GetAllAsync());
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var address = await _repository.GetAsync(id.Value);
        if (address == null)
        {
            return NotFound();
        }

        return View(address);
    }

    public virtual async Task<IActionResult> Create()
    {
        return await Task.FromResult(View());
    }

    [HttpPost]
    public async Task<IActionResult> Create(T entity)
    {
        await _repository.CreateAsync(entity);
        return RedirectToAction(nameof(Index));
    }

    public virtual async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var entity = await _repository.GetAsync(id.Value);
        if (entity == null)
        {
            return NotFound();
        }
        return View(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, T entity)
    {
        if (id != entity.Id)
        {
            return NotFound();
        }

        try
        {
            await _repository.UpdateAsync(id, entity);
        }
        catch
        {
            if (!await _repository.ExistsAsync(entity.Id))
            {
                return NotFound();
            }
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null || !await _repository.ExistsAsync(id.Value))
        {
            return NotFound();
        }

        await _repository.DeleteAsync(id.Value);

        return RedirectToAction(nameof(Index));
    }
}
