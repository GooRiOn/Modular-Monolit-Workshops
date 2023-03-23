using MySpot.Modules.Reservations.Core.Entities;

namespace MySpot.Modules.Reservations.Core.Policies;

public interface IReservationPolicy
{
    bool CanBeApplied(string jobTitle);
    bool CanReserve(IEnumerable<Reservation> reservations);
}