using Microsoft.Extensions.FileProviders;
using SmartRep_Backend.WebApi.Middlewares;

namespace SmartRep_Backend.WebApi.Extentions;

public static class MiddlewareRegistrator
{
    public static IApplicationBuilder UseSmartrepMiddlewares(this IApplicationBuilder app, WebApplicationBuilder builder)
    {
        if (builder.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<GlobalExceptionHandler>();

        app.UseHttpsRedirection();
        app.UseCors();
        app.UseAuthorization();

        app.UseSmartrepStaticFiles(builder);

        return app;
    }

    private static IApplicationBuilder UseSmartrepStaticFiles(this IApplicationBuilder app, WebApplicationBuilder builder)
    {
        var filesPath = Path.GetFullPath(Path.Combine(
            builder.Environment.ContentRootPath,
            builder.Configuration["FileStorage:LocalPath"] ?? "../SmartRep-Backend.Infrastructure/Data/files"
            ));

        Directory.CreateDirectory(filesPath);

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(filesPath),
            RequestPath = "/static-files"
        });
        return app;
    }
}