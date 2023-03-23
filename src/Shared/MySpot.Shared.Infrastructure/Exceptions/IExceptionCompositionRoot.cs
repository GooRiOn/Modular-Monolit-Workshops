using System;
using MySpot.Shared.Abstractions.Exceptions;

namespace MySpot.Shared.Infrastructure.Exceptions;

public interface IExceptionCompositionRoot
{
    ExceptionResponse Map(Exception exception);
}