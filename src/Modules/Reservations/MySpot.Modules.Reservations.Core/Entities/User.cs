using MySpot.Modules.Reservations.Core.Types;
using MySpot.Modules.Reservations.Core.ValueObjects;

namespace MySpot.Modules.Reservations.Core.Entities;

public class User
{
    public UserId Id { get; private set; }
    public JobTitle JobTitle { get; private set; }

    public User(UserId id, JobTitle jobTitle)
    {
        Id = id;
        JobTitle = jobTitle;
    }
}