using Lab5.Data;
using Lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Repositories;

public class GenericRepository<T> : IRepository<T> where T : ModelBase
{
    protected readonly LibraryDbContext Context;

    public GenericRepository(LibraryDbContext context) => Context = context;

    public virtual async Task<T> CreateAsync(T entity)
    {
        var result = await Context.Set<T>().AddAsync(entity);
        await Context.SaveChangesAsync();

        return result.Entity;
    }

    public virtual async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await Context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        if (entity == null)
        {
            return false;
        }
        Context.Set<T>().Remove(entity!);
        await Context.SaveChangesAsync();

        return true;
    }

    public virtual async Task<bool> ExistsAsync(Guid id)
    {
        return await Context.Set<T>().AnyAsync(e => e.Id == id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetAsync(Guid id)
    {
        var entity = await Context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

        return entity!;
    }

    public virtual async Task<T> UpdateAsync(Guid id, T entity)
    {
        entity.Id = id;
        var result = Context.Set<T>().Update(entity);
        await Context.SaveChangesAsync();

        return result.Entity;
    }
}
