using Lab8.Models;
using Lab8.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenericController<T> : ControllerBase where T : ModelBase, new()
{
    private readonly IRepository<T> _repository;

    public GenericController(IRepository<T> repository) => _repository = repository;

    [HttpGet]
    public async Task<IEnumerable<T>> Get()
    {
        return await _repository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<T> Get(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    [HttpPost]
    public async Task<T> Post([FromBody] T entity)
    {
        return await _repository.CreateAsync(entity);
    }

    [HttpPut("{id}")]
    public async Task<T> PutAsync(Guid id, [FromBody] T entity)
    {
        return await _repository.UpdateAsync(id, entity);
    }

    [HttpDelete("{id}")]
    public async void Delete(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
