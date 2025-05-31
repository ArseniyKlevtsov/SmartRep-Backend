using Microsoft.OpenApi.Models;

namespace SmartRep_Backend.WebApi.Extentions.ServiceRegistrators;

public static class Registrator
{
    public static IServiceCollection AddSmartRepServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddSwaggerWithJWT(configuration);

        services.AddInfrastructureServices(configuration);
        services.AddApplicationServices(configuration);
        services.AddAuhtServices(configuration);
        services.AddCorsServices(configuration);
        services.AddUseCases(configuration);

        return services;
    }

    public static IServiceCollection AddSwaggerWithJWT(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header. Example: 'Bearer {token}'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}
