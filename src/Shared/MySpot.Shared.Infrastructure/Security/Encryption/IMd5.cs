namespace MySpot.Shared.Infrastructure.Security.Encryption;

public interface IMd5
{
    string Calculate(string value);
}