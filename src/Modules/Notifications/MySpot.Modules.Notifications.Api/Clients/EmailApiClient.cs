using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using MySpot.Modules.Notifications.Api.Exceptions;

namespace MySpot.Modules.Notifications.Api.Clients;

internal sealed class EmailApiClient : IEmailApiClient
{
    private const string Url = "http://localhost:5090";
    private readonly IHttpClientFactory _factory;
    private readonly ILogger<EmailApiClient> _logger;

    public EmailApiClient(IHttpClientFactory factory, ILogger<EmailApiClient> logger)
    {
        _factory = factory;
        _logger = logger;
    }

    public async Task SendAsync(string receiver, string title, string body)
    {
        var client = _factory.CreateClient();

        try
        {
            var response = await client.PostAsJsonAsync($"{Url}/send-email", new {receiver, title, body});
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            throw new CannotSendEmailException(receiver);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            throw new CannotSendEmailException(receiver);
        }
    }
}