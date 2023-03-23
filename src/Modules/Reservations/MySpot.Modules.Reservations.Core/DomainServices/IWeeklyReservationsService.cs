using MySpot.Modules.Reservations.Core.Entities;
using MySpot.Modules.Reservations.Core.Types;
using MySpot.Modules.Reservations.Core.ValueObjects;

namespace MySpot.Modules.Reservations.Core.DomainServices;

public interface IWeeklyReservationsService
{
    Reservation Reserve(WeeklyReservations currentReservations, WeeklyReservations lastWeekReservations,
        ParkingSpotId parkingSpotId, Capacity capacity, LicensePlate licencePlate, Date date, string note);
}