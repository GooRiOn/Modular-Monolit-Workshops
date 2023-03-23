using MySpot.Shared.Abstractions.Commands;

namespace MySpot.Modules.Reservations.Application.Commands;

public record RemoveReservation(Guid UserId, Guid ReservationId) : ICommand;