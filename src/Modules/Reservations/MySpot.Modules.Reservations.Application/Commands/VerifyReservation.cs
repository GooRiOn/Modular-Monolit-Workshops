using MySpot.Shared.Abstractions.Commands;

namespace MySpot.Modules.Reservations.Application.Commands;

public record VerifyReservation(Guid WeeklyReservationsId, Guid ReservationId) : ICommand;