using MySpot.Modules.Reservations.Core.Entities;
using MySpot.Modules.Reservations.Core.ValueObjects;

namespace MySpot.Modules.Reservations.Core.Policies;

internal sealed class ManagerReservationPolicy : IReservationPolicy
{
    public bool CanBeApplied(string jobTitle)
        => jobTitle is JobTitle.Manager;

    public bool CanReserve(IEnumerable<Reservation> reservations)
    {
        var totalEmployeeReservations = reservations.Count();
        return totalEmployeeReservations <= 4;
    }
}