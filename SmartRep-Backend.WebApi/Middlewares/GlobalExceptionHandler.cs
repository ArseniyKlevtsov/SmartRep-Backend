using SmartRep_Backend.WebApi.Dtos;
using System.Net;
using System.Security.Authentication;

namespace SmartRep_Backend.WebApi.Middlewares;

public class GlobalExceptionHandler(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        ExceptionResponseDto response = exception switch
        {
            ArgumentException ex => new ExceptionResponseDto(HttpStatusCode.BadRequest, ex.Message),
            NotImplementedException ex => new ExceptionResponseDto(HttpStatusCode.NotImplemented, ex.Message),
            AuthenticationException ex => new ExceptionResponseDto(HttpStatusCode.Unauthorized, ex.Message),
            KeyNotFoundException ex => new ExceptionResponseDto(HttpStatusCode.NotFound, ex.Message),
            _ => new ExceptionResponseDto(HttpStatusCode.InternalServerError, "Internal server error. Please retry later. exception.Message:" + exception.Message)
        };

        // *потом над заменить на логирование ошибок =)*
        Console.WriteLine(exception.Message);
        Console.WriteLine(exception.StackTrace);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)response.StatusCode;
        await context.Response.WriteAsJsonAsync(response);
    }
}
