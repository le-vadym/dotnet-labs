namespace Lab5.Models;

public sealed class Reader : ModelBase
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public Guid AddressId { get; set; }
    public Address Address { get; set; } = null!;

    public string Description => $"{FirstName}, {LastName}";
}
