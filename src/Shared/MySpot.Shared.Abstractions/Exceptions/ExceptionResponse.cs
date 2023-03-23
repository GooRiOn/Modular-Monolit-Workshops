using System.Net;

namespace MySpot.Shared.Abstractions.Exceptions;

public record ExceptionResponse(object Response, HttpStatusCode StatusCode);