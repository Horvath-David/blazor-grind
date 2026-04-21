namespace GrindTwo.Data;

public class Moderator
{
    public int Id { get; set; }
    public required string Role { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string GivenName { get; set; }
    public required string FamilyName { get; set; }
    public required string Town { get; set; }
    public DateOnly Birthday { get; set; }
    public int PostalCode { get; set; }
    public required string StreetNumber { get; set; }
    public required string Phone { get; set; }
}