using MongoDB.Bson;

namespace Lab3.Models;

public sealed class Reader : ModelBase
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public Address Address { get; set; } = null!;
}
