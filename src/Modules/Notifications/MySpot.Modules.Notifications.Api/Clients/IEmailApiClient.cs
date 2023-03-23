namespace MySpot.Modules.Notifications.Api.Clients;

public interface IEmailApiClient
{
    Task SendAsync(string receiver, string title, string body);
}