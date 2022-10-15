using Lab4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab4.Configurations;

internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(r => r.Name).IsRequired();
        builder.Property(r => r.Author).IsRequired();
        builder.Property(x => x.Price).IsRequired().HasColumnType("money").HasPrecision(6);
    }
}
