namespace MySpot.Modules.Availability.Application;

public interface IAppContext
{
    string RequestId { get; }
    IIdentityContext Identity { get; }
}