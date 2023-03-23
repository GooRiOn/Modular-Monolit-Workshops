using MySpot.Shared.Abstractions.Auth;

namespace MySpot.Modules.Users.Core.Services;

public interface ITokenStorage
{
    void Set(JsonWebToken jwt);
    JsonWebToken Get();
}