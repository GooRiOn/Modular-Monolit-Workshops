using MySpot.Shared.Abstractions.Commands;

namespace MySpot.Modules.Notifications.Api.Commands;

public record SendEmail(Guid UserId, string Template) : ICommand;