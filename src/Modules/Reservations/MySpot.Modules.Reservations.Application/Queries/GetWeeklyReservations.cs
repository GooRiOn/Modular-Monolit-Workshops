using MySpot.Modules.Reservations.Application.DTO;
using MySpot.Shared.Abstractions.Queries;

namespace MySpot.Modules.Reservations.Application.Queries;

public class GetWeeklyReservations : IQuery<WeeklyReservationsDto>
{
    public Guid UserId { get; set; }
    public DateTime? Date { get; set; }
}