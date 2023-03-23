using MySpot.Shared.Abstractions.Commands;

namespace MySpot.Modules.Reservations.Application.Commands;

public record MakeReservationIncorrect(Guid WeeklyReservationsId, Guid ReservationId) : ICommand;