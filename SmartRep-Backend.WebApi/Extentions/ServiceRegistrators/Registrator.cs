﻿namespace SmartRep_Backend.WebApi.Extentions.ServiceRegistrators;

public static class Registrator
{
    public static IServiceCollection AddSmartRepServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddInfrastructureServices(configuration);
        services.AddApplicationServices(configuration);
        services.AddAuhtServices(configuration);
        services.AddCorsServices(configuration);
        services.AddUseCases(configuration);

        return services;
    }
}
