using MySpot.Modules.Availability.Core.ValueObjects;

namespace MySpot.Modules.Availability.Core.Entities;

public class Reservation 
{
    public ReservationId Id { get; }
    public Capacity Capacity { get; }
    public Date Date { get; }
    public int Priority { get; }

    public Reservation(ReservationId id, Capacity capacity, Date date, int priority)
        => (Id, Capacity, Date, Priority) = (id, capacity, date, priority);

    private Reservation()
    {
    }
}