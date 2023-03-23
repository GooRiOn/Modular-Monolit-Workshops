using MySpot.Modules.Reservations.Core.Entities;
using MySpot.Modules.Reservations.Core.ValueObjects;

namespace MySpot.Modules.Reservations.Core.Policies;

internal sealed class BossReservationPolicy : IReservationPolicy
{
    public bool CanBeApplied(string jobTitle)
        => jobTitle is JobTitle.Boss;

    public bool CanReserve(IEnumerable<Reservation> reservations)
        => true;
}