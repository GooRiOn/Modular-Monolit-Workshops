using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Users.Core.Exceptions;

internal class SignUpDisabledException : CustomException
{
    public SignUpDisabledException() : base("Sign up is disabled.")
    {
    }
}