using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Modules.Notifications.Api.Exceptions;

internal sealed class TemplateNotFoundException : CustomException
{
    public string Name { get; }

    public TemplateNotFoundException(string name) : base($"Template: '{name}' was not found.")
    {
        Name = name;
    }
}