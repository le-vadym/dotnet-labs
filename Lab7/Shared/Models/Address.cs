namespace Lab7.Models;

public sealed class Address : ModelBase
{
    public string Country { get; set; } = null!;
    public string Region { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public int HouseNumber { get; set; }

    public string Description => $"{Country}, {Region}, {City}, {Street}, {HouseNumber}";
}
