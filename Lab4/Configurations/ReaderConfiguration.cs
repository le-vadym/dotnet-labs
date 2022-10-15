using Lab4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab4.Configurations;

internal sealed class ReaderConfiguration : IEntityTypeConfiguration<Reader>
{
    public void Configure(EntityTypeBuilder<Reader> builder)
    {
        builder.Property(r => r.FirstName).IsRequired();
        builder.Property(r => r.LastName).IsRequired();
        builder.Property(r => r.BirthDate).IsRequired();
        builder.Property(r => r.PhoneNumber).IsRequired();
    }
}
