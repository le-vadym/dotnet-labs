using Lab4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab4.Configurations;

internal class BookBorrowConfiguration : IEntityTypeConfiguration<BookBorrow>
{
    public void Configure(EntityTypeBuilder<BookBorrow> builder)
    {
        builder.Property(b => b.BorrowDate).IsRequired();
    }
}
