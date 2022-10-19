using Lab5.Data;
using Lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Repositories;

public class BookBorrowRepository : GenericRepository<BookBorrow>
{
    public BookBorrowRepository(LibraryDbContext context) : base(context) { }

    public override async Task<IEnumerable<BookBorrow>> GetAllAsync()
    {
        return await Context.Set<BookBorrow>()
            .AsNoTracking()
            .Include(b => b.Reader)
            .Include(b => b.Book)
            .ToListAsync();
    }

    public override async Task<BookBorrow> GetAsync(Guid id)
    {
        var entity = await Context.Set<BookBorrow>()
            .AsNoTracking()
            .Include(b => b.Reader)
            .Include(b => b.Book)
            .FirstOrDefaultAsync(e => e.Id == id);

        return entity!;
    }
}
