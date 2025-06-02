using SmartRep_Backend.Application.Interfaces.UseCases.AuthUseCases;
using SmartRep_Backend.Application.Interfaces.UseCases.UserUseCases;
using SmartRep_Backend.Application.UseCases.AuthUseCases;
using SmartRep_Backend.Application.UseCases.UserUseCases;

namespace SmartRep_Backend.WebApi.Extentions.ServiceRegistrators;

public static class UseCasesRegistrator
{
    public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration)
    {
        // Auth
        services.AddTransient<IRegister, Register>();
        services.AddTransient<ILogin, Login>();

        // Users
        services.AddTransient<IGetShortcutUserProfile, GetShortcutUserProfile>();

        //
        return services;
    }
}
