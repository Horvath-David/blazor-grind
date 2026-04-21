namespace GrindTwo.Data;

public class Event
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public decimal PriceInEuro { get; set; }
    public required string Program { get; set; }
    public required string Pictures { get; set; }
    public required string State { get; set; }
    public required string RejectionReason { get; set; }

    public int VenueId { get; set; }
    public Venue? Venue { get; set; }

    public int OrganizerId { get; set; }
    public Organizer? Organizer { get; set; }
}