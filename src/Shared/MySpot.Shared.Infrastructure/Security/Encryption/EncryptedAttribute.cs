using System;

namespace MySpot.Shared.Infrastructure.Security.Encryption;

[AttributeUsage(AttributeTargets.Property)]
public class EncryptedAttribute : Attribute
{
}