namespace MySpot.Modules.Reservations.Application.DTO;

public class WeeklyReservationsDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime From { get; }
    public DateTime To { get; }
    public IEnumerable<ReservationDto> Reservations { get; set; }
}