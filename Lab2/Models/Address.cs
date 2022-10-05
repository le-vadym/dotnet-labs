namespace Lab2.Models;

internal sealed class Address
{
    public Guid Id { get; set; }
    public string Country { get; set; } = null!;
    public string Region { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public int HouseNumber { get; set; }
}
