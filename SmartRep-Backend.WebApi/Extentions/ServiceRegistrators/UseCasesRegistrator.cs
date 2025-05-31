using SmartRep_Backend.Application.Interfaces.UseCases.AuthUseCases;
using SmartRep_Backend.Application.UseCases.AuthUseCases;

namespace SmartRep_Backend.WebApi.Extentions.ServiceRegistrators;

public static class UseCasesRegistrator
{
    public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration)
    {
        // Auth
        services.AddTransient<IRegisterUseCase, Register>();
        services.AddTransient<ILoginUseCase, Login>();

        // 


        //
        return services;
    }
}
