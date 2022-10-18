﻿using Lab4.Data;
using Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Repositories;

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
}
