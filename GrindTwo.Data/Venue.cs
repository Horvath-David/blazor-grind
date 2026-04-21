
namespace GrindTwo.Data;

public class Venue
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Location { get; set; }

    public ICollection<Event> Events { get; set; } = [];
}