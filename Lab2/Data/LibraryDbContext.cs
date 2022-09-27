using Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Data;

internal sealed class LibraryDbContext : DbContext
{
    public DbSet<Reader>? Readers { get; set; }
    public DbSet<Book>? Books { get; set; }
    public DbSet<Address>? Addresses { get; set; }
    public DbSet<BookBorrow>? BookBorrows { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Reader config
        modelBuilder.Entity<Reader>().Property(r => r.FirstName).IsRequired();
        modelBuilder.Entity<Reader>().Property(r => r.LastName).IsRequired();
        modelBuilder.Entity<Reader>().Property(r => r.BirthDate).IsRequired();
        modelBuilder.Entity<Reader>().Property(r => r.PhoneNumber).IsRequired();
        #endregion

        #region Book config
        modelBuilder.Entity<Book>().Property(r => r.Name).IsRequired();
        modelBuilder.Entity<Book>().Property(r => r.Author).IsRequired();
        modelBuilder.Entity<Book>().Property(x => x.Price).HasColumnType("money").HasPrecision(6).IsRequired();
        #endregion

        #region Address config
        modelBuilder.Entity<Address>().Property(a => a.Country).IsRequired();
        modelBuilder.Entity<Address>().Property(a => a.Region).IsRequired();
        modelBuilder.Entity<Address>().Property(a => a.Street).IsRequired();
        modelBuilder.Entity<Address>().Property(a => a.HouseNumber).IsRequired();
        #endregion

        #region BookBorrow config
        modelBuilder.Entity<BookBorrow>().Property(b => b.BorrowDate).IsRequired();
        #endregion
    }
}
