using MySpot.Modules.Availability.Core.Exceptions;

namespace MySpot.Modules.Availability.Core.ValueObjects;

public record Tag(string Value)
{
    public string Value { get; } = Value ?? throw new InvalidResourceTagsException();
    
    public static implicit operator Tag(string value) => new(value);
    public static implicit operator string(Tag tag) => tag.Value;
}