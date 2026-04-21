namespace GrindTwo.Data;

public class Organizer
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string PreName { get; set; }
    public required string FamilyName { get; set; }
    public required string PostalCodeAndTown { get; set; }
    public DateOnly Birthday { get; set; }
    public required string Address { get; set; }
    public required string Phone { get; set; }
    public required string Hobby { get; set; }

    public ICollection<Event> Events { get; set; } = [];
}