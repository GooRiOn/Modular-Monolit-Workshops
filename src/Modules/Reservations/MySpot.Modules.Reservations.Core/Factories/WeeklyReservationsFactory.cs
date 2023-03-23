using MySpot.Modules.Reservations.Core.Entities;
using MySpot.Modules.Reservations.Core.Exceptions;
using MySpot.Modules.Reservations.Core.Repositories;
using MySpot.Modules.Reservations.Core.Types;
using MySpot.Modules.Reservations.Core.ValueObjects;
using MySpot.Shared.Abstractions.Domain;

namespace MySpot.Modules.Reservations.Core.Factories;

internal sealed class WeeklyReservationsFactory : IWeeklyReservationsFactory
{
    private readonly IUserRepository _userRepository;

    public WeeklyReservationsFactory(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<WeeklyReservations> CreateAsync(UserId userId, Week week,
        CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetAsync(userId, cancellationToken);
        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }
        
        return new WeeklyReservations(AggregateId.Create(), user, week);
    }
}