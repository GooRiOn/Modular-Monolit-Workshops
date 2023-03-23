using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Users.Core.Exceptions;

internal class EmailInUseException : CustomException
{
    public EmailInUseException() : base("Email is already in use.")
    {
    }
}