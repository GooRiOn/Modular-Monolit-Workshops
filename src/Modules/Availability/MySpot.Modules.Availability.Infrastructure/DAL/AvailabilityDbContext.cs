using Microsoft.EntityFrameworkCore;
using MySpot.Modules.Availability.Core.Entities;

namespace MySpot.Modules.Availability.Infrastructure.DAL;

internal class AvailabilityDbContext : DbContext
{
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Resource> Resources { get; set; }
        
    public AvailabilityDbContext(DbContextOptions<AvailabilityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("availability");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}