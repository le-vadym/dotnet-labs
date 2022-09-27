namespace Lab2.Models;

internal sealed class Address
{
    public Guid Id { get; set; }
    public string Country { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int HouseNumber { get; set; }
}
