using Lab2.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Lab2.Data;

internal sealed class LibraryDbContext : DbContext
{
    public DbSet<Reader> Readers { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<BookBorrow> BookBorrows { get; set; } = null!;

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
