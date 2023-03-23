using Microsoft.IdentityModel.Tokens;

namespace MySpot.Shared.Infrastructure.Auth.JWT;

internal sealed record SecurityKeyDetails(SecurityKey Key, string Algorithm);
