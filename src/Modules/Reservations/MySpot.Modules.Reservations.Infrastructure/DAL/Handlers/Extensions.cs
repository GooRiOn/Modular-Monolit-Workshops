using MySpot.Modules.Reservations.Application.DTO;
using MySpot.Modules.Reservations.Core.Entities;

namespace MySpot.Modules.Reservations.Infrastructure.DAL.Handlers;

internal static class Extensions
{
    public static WeeklyReservationsDto AsDto(this WeeklyReservations entity)
        => new()
        {
            Id = entity.Id,
            UserId = entity.UserId,
            Reservations = entity.Reservations.Select(x => new ReservationDto
            {
                Id = x.Id,
                ParkingSpotId = x.ParkingSpotId,
                Capacity = x.Capacity,
                Date = x.Date.Value.DateTime,
                LicensePlate = x.LicensePlate,
                Note = x.Note,
                State = x.State
            })
        };
}