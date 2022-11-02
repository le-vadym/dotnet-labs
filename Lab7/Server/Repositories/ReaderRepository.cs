using Lab7.Data;
using Lab7.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Lab7.Repositories;

public class ReadersRepository : GenericRepository<Reader>
{
    public ReadersRepository(LibraryDbContext context) : base(context) { }

    public override async Task<IEnumerable<Reader>> GetAllAsync()
    {
        return await Context.Set<Reader>()
            .AsNoTracking()
            .Include(r => r.Address)
            .ToListAsync();
    }

    public override async Task<Reader> GetAsync(Guid id)
    {
        var entity = await Context.Set<Reader>()
            .AsNoTracking()
            .Include(r => r.Address)
            .FirstOrDefaultAsync(e => e.Id == id);

        return entity!;
    }

    public override async Task<Reader> CreateAsync(Reader entity)
    {
        entity.Address = null;
        return await base.CreateAsync(entity);
    }

    public override async Task<Reader> UpdateAsync(Guid id, Reader entity)
    {
        entity.Address = null;
        return await base.UpdateAsync(id, entity);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await Context.Set<Reader>().FirstOrDefaultAsync(e => e.Id == id);
        if (entity == null)
        {
            return false;
        }

        entity.AddressId = Guid.Empty;
        Context.Set<Reader>().Remove(entity!);
        await Context.SaveChangesAsync();

        return true;
    }
}
