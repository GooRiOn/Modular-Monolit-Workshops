using MySpot.Modules.Reservations.Core.Entities;
using MySpot.Modules.Reservations.Core.ValueObjects;
using MySpot.Shared.Abstractions.Time;

namespace MySpot.Modules.Reservations.Core.Policies;

internal sealed class RegularEmployeeReservationPolicy : IReservationPolicy
{
    private readonly IClock _clock;

    public RegularEmployeeReservationPolicy(IClock clock)
        => _clock = clock;

    public bool CanBeApplied(string jobTitle)
        => jobTitle is JobTitle.Employee;

    public bool CanReserve(IEnumerable<Reservation> reservations)
    {
        var totalEmployeeReservations = reservations.Count();
        return totalEmployeeReservations <= 4 && _clock.CurrentDate().Hour > 4;
    }
}