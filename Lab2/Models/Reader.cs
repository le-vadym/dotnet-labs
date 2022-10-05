namespace Lab2.Models;

internal sealed class Reader
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public Address Address { get; set; } = null!;
}
