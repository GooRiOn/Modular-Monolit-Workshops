using System;

namespace MySpot.Shared.Abstractions.Exceptions;

public interface IExceptionToResponseMapper
{
    ExceptionResponse Map(Exception exception);
}