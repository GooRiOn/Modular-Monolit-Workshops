using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Reservations.Application.Exceptions;

public sealed class WeeklyReservationsForCurrentWeekNotFound : CustomException
{
    public WeeklyReservationsForCurrentWeekNotFound() 
        : base($"Reservations for current week not found.")
    {
    }
}