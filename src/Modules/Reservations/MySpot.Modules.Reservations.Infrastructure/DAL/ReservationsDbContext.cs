using Microsoft.EntityFrameworkCore;
using MySpot.Modules.Reservations.Core.Entities;

namespace MySpot.Modules.Reservations.Infrastructure.DAL;

internal class ReservationsDbContext : DbContext
{
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<WeeklyReservations> WeeklyReservations { get; set; }
    public DbSet<User> Users { get; set; }
        
    public ReservationsDbContext(DbContextOptions<ReservationsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("reservations");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}