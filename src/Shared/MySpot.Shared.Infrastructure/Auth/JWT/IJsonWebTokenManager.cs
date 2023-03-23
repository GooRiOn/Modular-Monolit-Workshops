using System.Collections.Generic;
using MySpot.Shared.Abstractions.Auth;

namespace MySpot.Shared.Infrastructure.Auth.JWT;

public interface IJsonWebTokenManager
{
    JsonWebToken CreateToken(string userId, string email = null, string role = null,
        IDictionary<string, IEnumerable<string>> claims = null);
}