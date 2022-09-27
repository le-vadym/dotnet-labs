using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Lab2.Data;

internal sealed class LibraryDbContextFactory : IDbContextFactory<LibraryDbContext>, IDesignTimeDbContextFactory<LibraryDbContext>
{
    public LibraryDbContext CreateDbContext()
    {
        DbContextOptionsBuilder<LibraryDbContext> optionsBuilder = new();
        optionsBuilder.UseSqlServer(Configuration.ConnectionString);

        return new LibraryDbContext(optionsBuilder.Options);
    }

    public LibraryDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<LibraryDbContext> optionsBuilder = new();
        optionsBuilder.UseSqlServer(Configuration.ConnectionString);

        return new LibraryDbContext(optionsBuilder.Options);
    }
}
