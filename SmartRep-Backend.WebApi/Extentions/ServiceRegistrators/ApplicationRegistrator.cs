using FluentValidation;
using SmartRep_Backend.Application.Mapping;
using SmartRep_Backend.Application.Services;
using SmartRep_Backend.Application.Validators.AuthValidatros;
using SmartRep_Backend.Domain.interfaces.Services;

namespace SmartRep_Backend.WebApi.Extentions.ServiceRegistrators;

public static class ApplicationRegistrator
{ 
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(UserProfile).Assembly);

        services.AddValidatorsFromAssemblyContaining<LoginRequestDtoValidator>();

        services.AddScoped<IPasswordService, PasswordService>();

        return services;
    }
}
