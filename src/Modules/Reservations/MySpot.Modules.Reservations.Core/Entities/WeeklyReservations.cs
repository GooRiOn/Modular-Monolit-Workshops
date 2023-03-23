using MySpot.Modules.Reservations.Core.Exceptions;
using MySpot.Modules.Reservations.Core.Policies;
using MySpot.Modules.Reservations.Core.Types;
using MySpot.Modules.Reservations.Core.ValueObjects;
using MySpot.Shared.Abstractions.Domain;

namespace MySpot.Modules.Reservations.Core.Entities;

public class WeeklyReservations : AggregateRoot
{
    private readonly JobTitle _jobTitle = JobTitle.None;
    private readonly HashSet<Reservation> _reservations = new();

    public UserId UserId { get; private set; }
    public Week Week { get; private set; }
    public IEnumerable<Reservation> Reservations => _reservations;
    
    private WeeklyReservations()
    {
    }
    
    public WeeklyReservations(AggregateId id, User user, Week week)
    {
        Id = id;
        UserId = user.Id;
        Week = week;
        _jobTitle = user.JobTitle;
        IncrementVersion();
    }

    internal void AddReservation(Reservation reservation, Date now, IEnumerable<IReservationPolicy> policies)
    {
        if (reservation.Date <= now ||  reservation.Date < Week.From || reservation.Date > Week.To)
        {
            throw new InvalidReservationDateException(reservation.Date.Value);
        }
        
        if (_reservations.Any(x => x.ParkingSpotId == reservation.ParkingSpotId && x.Date == reservation.Date))
        {
            throw new ParkingSpotAlreadyReservedException(reservation.ParkingSpotId, reservation.Date);
        }
        
        var policy = policies.SingleOrDefault(p => p.CanBeApplied(_jobTitle));
        if (policy is null)
        {
            throw new NoReservationPolicyFoundException(_jobTitle);
        }

        if (!policy.CanReserve(_reservations))
        {
            throw new CannotMakeReservationException(reservation.ParkingSpotId);
        }

        _reservations.Add(reservation);
        IncrementVersion();
    }

    public Reservation RemoveReservation(ReservationId reservationId)
    {
        var reservation = GetReservation(reservationId);
        _reservations.Remove(reservation);
        IncrementVersion();

        return reservation;
    }

    public void RemoveReservations(IEnumerable<Reservation> reservations)
    {
        _reservations.RemoveWhere(r => reservations.Any(rr => rr.Id == r.Id));
        IncrementVersion();
    }
    
    public void ChangeReservationsNote(ReservationId reservationId, string note)
    {
        var reservation = GetReservation(reservationId);
        reservation.ChangeNote(note);
        IncrementVersion();
    }

    public void ChangeLicensePlate(ReservationId reservationId, LicensePlate licensePlate)
    {
        var reservation = GetReservation(reservationId);
        reservation.ChangeLicensePlate(licensePlate);
        IncrementVersion();
    }
    
    public void MarkReservationAsVerified(ReservationId reservationId)
    {
        var reservation = GetReservation(reservationId);
        reservation.MarkAsVerified();
        IncrementVersion();
    }
    
    public void MarkReservationAsIncorrect(ReservationId reservationId)
    {
        var reservation = GetReservation(reservationId);
        reservation.MarkAsIncorrect();
        IncrementVersion();
    }

    private Reservation GetReservation(ReservationId reservationId)
    {
        var reservation = _reservations.FirstOrDefault(r => r.Id == reservationId);

        if (reservation is null)
        {
            throw new ReservationNotFoundException(reservationId);
        }
        if (reservation.Date < Date.Now)
        {
            throw new CannotModifyPastReservationException(reservation.Date);
        }

        return reservation;
    }
}