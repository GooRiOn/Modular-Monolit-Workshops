using MySpot.Shared.Abstractions.Commands;

namespace MySpot.Modules.Reservations.Application.Commands;

public record CreateWeeklyReservations(Guid UserId) : ICommand;