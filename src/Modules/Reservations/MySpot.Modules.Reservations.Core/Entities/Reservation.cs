using MySpot.Modules.Reservations.Core.Types;
using MySpot.Modules.Reservations.Core.ValueObjects;

namespace MySpot.Modules.Reservations.Core.Entities;

public class Reservation
{
    public ReservationId Id { get; private set; }
    public ParkingSpotId ParkingSpotId { get; private set; }
    public Capacity Capacity { get; private set;}
    public LicensePlate LicensePlate { get; private set; }
    public Date Date { get; private set; }
    public string Note { get; private set; }
    public ReservationState State { get; private set; }

    private Reservation()
    {
    }
    
    internal Reservation(ReservationId id, ParkingSpotId parkingSpotId, Capacity capacity, 
        LicensePlate licensePlate, Date date, string note  = null)
    {
        Id = id;
        ParkingSpotId = parkingSpotId;
        Capacity = capacity;
        LicensePlate = licensePlate;
        Date = date;
        Note = note;
        State = ReservationState.Unverified;
    }

    internal void ChangeNote(string note)
        => Note = note;
    
    internal void ChangeLicensePlate(LicensePlate licensePlate)
        => LicensePlate = licensePlate;

    internal void MarkAsVerified()
        => State = ReservationState.Verified;
    
    internal void MarkAsIncorrect()
        => State = ReservationState.Incorrect;
}