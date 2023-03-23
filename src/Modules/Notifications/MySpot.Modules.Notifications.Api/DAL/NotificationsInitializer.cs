using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySpot.Modules.Notifications.Api.Entities;
using MySpot.Shared.Infrastructure;

namespace MySpot.Modules.Notifications.Api.DAL;

internal sealed class NotificationsInitializer : IInitializer
{
    private readonly NotificationsDbContext _dbContext;
    private readonly ILogger<NotificationsInitializer> _logger;

    public NotificationsInitializer(NotificationsDbContext dbContext, ILogger<NotificationsInitializer> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task InitAsync()
    {
        if (await _dbContext.Templates.AnyAsync())
        {
            return;
        }

        await AddTemplatesAsync();
        await _dbContext.SaveChangesAsync();
    }

    private async Task AddTemplatesAsync()
    {
        await _dbContext.Templates.AddAsync(new Template(Guid.NewGuid(), "account_created", "Account created",
            "Your account has been created"));
        await _dbContext.Templates.AddAsync(new Template(Guid.NewGuid(), "reservation_added", "Reservation added",
            "Reservation has been added"));
        _logger.LogInformation("Initialized templates.");
    }
}