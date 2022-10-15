using Lab4.Data;
using Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Repositories;

public class GenericRepository<T> : IRepository<T> where T : ModelBase
{
    private readonly LibraryDbContext _context;

    public GenericRepository(LibraryDbContext context) => _context = context;

    public async Task<T> CreateAsync(T entity)
    {
        var result = await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        if (entity == null)
        {
            return false;
        }
        _context.Set<T>().Remove(entity!);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetAsync(Guid id)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

        return entity!;
    }

    public async Task<T> UpdateAsync(Guid id, T entity)
    {
        entity.Id = id;
        var result = _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();

        return result.Entity;
    }
}
