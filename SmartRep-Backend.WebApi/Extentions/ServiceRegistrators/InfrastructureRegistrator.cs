using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.interfaces.Repositories;
using SmartRep_Backend.Domain.interfaces.Services;
using SmartRep_Backend.Infrastructure.Data;
using SmartRep_Backend.Infrastructure.Repositories;
using SmartRep_Backend.Infrastructure.Services;

namespace SmartRep_Backend.WebApi.Extentions.ServiceRegistrators;

public static class InfrastructureRegistrator
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SmartRepDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("MySqlConnection"),
                new MySqlServerVersion(new Version(8, 0, 42))
            ));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IFileStorageService, LocalFileStorageService>();

        services.AddScoped<ITokenService>(_ =>
            new TokenService(
                secretKey: configuration["Jwt:Key"]!,
                issuer: configuration["Jwt:Issuer"]!,
                audience: configuration["Jwt:Audience"]!,
                expiryHours: configuration.GetValue<int>("Jwt:AccessTokenExpirationHours")
            )
        );

        return services;
    }

}
