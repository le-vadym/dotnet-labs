using Lab8.Data;
using Lab8.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab8.Repositories;

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

    public override async Task<BookBorrow> CreateAsync(BookBorrow entity)
    {
        entity.Book = null;
        entity.Reader = null;
        return await base.CreateAsync(entity);
    }

    public override async Task<BookBorrow> UpdateAsync(Guid id, BookBorrow entity)
    {
        entity.Book = null;
        entity.Reader = null;
        return await base.UpdateAsync(id, entity);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await Context.Set<BookBorrow>().FirstOrDefaultAsync(e => e.Id == id);
        if (entity == null)
        {
            return false;
        }

        entity.BookId = Guid.Empty;
        entity.ReaderId = Guid.Empty;
        Context.Set<BookBorrow>().Remove(entity!);
        await Context.SaveChangesAsync();

        return true;
    }
}
