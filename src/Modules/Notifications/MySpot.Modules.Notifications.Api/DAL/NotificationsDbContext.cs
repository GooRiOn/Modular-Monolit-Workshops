using Microsoft.EntityFrameworkCore;
using MySpot.Modules.Notifications.Api.Entities;

namespace MySpot.Modules.Notifications.Api.DAL;

internal sealed class NotificationsDbContext : DbContext
{
    public DbSet<Template> Templates { get; set; }
    public DbSet<User> Users { get; set; }
        
    public NotificationsDbContext(DbContextOptions<NotificationsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("notifications");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}