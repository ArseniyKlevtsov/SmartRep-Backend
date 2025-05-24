using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SmartRep_Backend.Application.Validators.AuthValidatros;

namespace SmartRep_Backend.WebApi.Extentions.ServiceRegistrators;

public static class ApplicationRegistrator
{ 
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddAutoMapper(typeof(UserProfile).Assembly);

        services.AddValidatorsFromAssemblyContaining<LoginRequestDtoValidator>();

        return services;
    }
}
