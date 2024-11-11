using System.Net;
using System.Text.Json;
using GlobalExceptionHandler.CustomExceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GlobalExceptionHandler;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = "application/json";

        ProblemDetails problemDetails = new ProblemDetails
        {
            Status = 500,
            Title = "An unexpected error occurred.",
            Detail = exception.Message,
            Instance = httpContext.Request.Path
        };

        switch (exception)
        {
            case BadRequestException badException:
                problemDetails.Status = (int)HttpStatusCode.BadRequest;
                problemDetails.Title = "Bad Request";
                problemDetails.Detail = badException.Message;
                break;
            
            case AlreadyException alreadyException:
                problemDetails.Status = (int)HttpStatusCode.Conflict;
                problemDetails.Title = "Conflict";
                problemDetails.Detail = alreadyException.Message;
                break;
            
            case NotFoundException notFoundException:
                problemDetails.Status = (int)HttpStatusCode.NotFound;
                problemDetails.Title = "Not Found";
                problemDetails.Detail = notFoundException.Message;
                break;
            
            case InternalServerException internalServerException:
                problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                problemDetails.Title = "Internal Server Error";
                problemDetails.Detail = internalServerException.Message;
                break;
        }

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problemDetails), cancellationToken);

        return true;
    }
}