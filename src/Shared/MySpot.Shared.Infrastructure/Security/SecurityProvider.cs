using System.Text.Encodings.Web;
using Microsoft.Extensions.Options;
using MySpot.Shared.Infrastructure.Security.Encryption;

namespace MySpot.Shared.Infrastructure.Security;

public sealed class SecurityProvider : ISecurityProvider
{
    private readonly IEncryptor _encryptor;
    private readonly IHasher _hasher;
    private readonly IRng _rng;
    private readonly UrlEncoder _urlEncoder;
    private readonly string _key;
    private readonly bool _enabled;

    public SecurityProvider(IEncryptor encryptor, IHasher hasher,
        IRng rng, UrlEncoder urlEncoder, IOptions<SecurityOptions> securityOptions)
    {
        _encryptor = encryptor;
        _hasher = hasher;
        _rng = rng;
        _urlEncoder = urlEncoder;
        _enabled = securityOptions.Value.Encryption.Enabled;
        _key = securityOptions.Value.Encryption.Key;
    }

    public string Encrypt(string data)
        => _enabled ? _encryptor.Encrypt(data, _key) : data;

    public string Decrypt(string data)
        => _enabled ? _encryptor.Decrypt(data, _key) : data;

    public string Hash(string data) => _hasher.Hash(data);

    public string Rng(int length, bool removeSpecialChars = true) => _rng.Generate(length, removeSpecialChars);

    public string Sanitize(string value) => _urlEncoder.Encode(value);
}