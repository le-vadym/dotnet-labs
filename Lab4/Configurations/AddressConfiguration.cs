using Lab4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab4.Configurations;

internal sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(a => a.Country).IsRequired();
        builder.Property(a => a.City).IsRequired();
        builder.Property(a => a.Street).IsRequired();
        builder.Property(a => a.HouseNumber).IsRequired();
    }
}
