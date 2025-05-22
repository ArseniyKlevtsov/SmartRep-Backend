namespace SmartRep_Backend.WebApi.Extentions.ServiceRegistrators;

public static class CorsRegistrator
{
    public static IServiceCollection AddCorsServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins(configuration["ClientApp:Url"] ?? "http://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
        });
        return services;
    }
}
