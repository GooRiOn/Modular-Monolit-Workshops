using MySpot.Shared.Abstractions.Commands;

namespace MySpot.Modules.Reservations.Application.Commands;

public record ChangeReservationLicencePlate(Guid WeeklyReservationsId, Guid ReservationId, string Note) : ICommand;