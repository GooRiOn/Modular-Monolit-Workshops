using System;

namespace MySpot.Shared.Abstractions.Exceptions;

public abstract class CustomException : Exception
{
    protected CustomException(string message) : base(message)
    {
    }
}