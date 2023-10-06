using System.ComponentModel;
using System.Text.Json;
using FluentValidation;

namespace QuizzService.Api.Exceptions;

public sealed class ExceptionsHandlingMiddleware : IMiddleware
{
    private readonly Core.Logging.ILogger logger;

    public ExceptionsHandlingMiddleware(Core.Logging.ILogger logger)
    {
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException validationExceptions)
        {
            var errors = validationExceptions.Errors;
            await HandleExceptionAsync(
                context,
                int.Parse(errors.ElementAt(0).ErrorCode),
                errors.Select(error => error.ErrorMessage).ToArray());
        }
        catch (Exception exception)
        {
            logger.LogError(exception.Message);

            await HandleExceptionAsync(
                context,
                StatusCodes.Status500InternalServerError,
                new string[] { exception.Message });
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, int statusCode, string[] errors)
    {
        var response = new
        {
            statusCode,
            errors
        };

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}