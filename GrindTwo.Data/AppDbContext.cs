using Microsoft.EntityFrameworkCore;

namespace GrindTwo.Data;

public partial class AppDbContext : DbContext
{

    public DbSet<Event> Events { get; set; }
    public DbSet<Moderator> Moderators { get; set; }
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<Venue> Venues { get; set; }

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("DataSource=db.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organizer>()
            .HasMany(e => e.Events)
            .WithOne(e => e.Organizer)
            .HasForeignKey(e => e.OrganizerId)
            .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<Venue>()
            .HasMany(e => e.Events)
            .WithOne(e => e.Venue)
            .HasForeignKey(e => e.VenueId)
            .HasPrincipalKey(e => e.Id);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
