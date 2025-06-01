using SmartRep_Backend.Infrastructure.Data;

namespace SmartRep_Backend.WebApi.Middlewares;

public class DatabaseInitializerMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context, DatabaseInitializer initializer)
    {
        initializer.Initialize();
        await _next(context);
    }
}
