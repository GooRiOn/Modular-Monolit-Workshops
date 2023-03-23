using MySpot.Modules.Reservations.Core.Entities;
using MySpot.Modules.Reservations.Core.Exceptions;
using MySpot.Modules.Reservations.Core.Policies;
using MySpot.Modules.Reservations.Core.Types;
using MySpot.Modules.Reservations.Core.ValueObjects;
using MySpot.Shared.Abstractions.Time;

namespace MySpot.Modules.Reservations.Core.DomainServices;

public sealed class WeeklyReservationsService : IWeeklyReservationsService
{
    private readonly IEnumerable<IReservationPolicy> _policies;
    private readonly IClock _clock;

    public WeeklyReservationsService(IEnumerable<IReservationPolicy> policies, IClock clock)
    {
        _policies = policies;
        _clock = clock;
    }
    
    public Reservation Reserve(WeeklyReservations currentReservations, WeeklyReservations lastWeekReservations,
        ParkingSpotId parkingSpotId, Capacity capacity, LicensePlate licensePlate, Date date, string note = null)
    {
        if (lastWeekReservations is not null)
        {
            var hadAnyIncorrectReservation = lastWeekReservations.Reservations
                .Any(r => r.State == ReservationState.Incorrect);

            if (hadAnyIncorrectReservation)
            {
                throw new CannotMakeReservationException(parkingSpotId);
            }
        }

        var reservation = new Reservation(ReservationId.Create(), parkingSpotId, capacity, licensePlate, date, note);
        currentReservations.AddReservation(reservation, new Date(_clock.CurrentDate()), _policies);

        return reservation;
    }
}