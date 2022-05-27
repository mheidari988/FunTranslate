using FunTranslate.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FunTranslate.Infrastructure;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // TODO: Add https://api.funtranslations.com/translate/ to configuration and remove this comment
        services.AddHttpClient(ApplicationConsts.HttpClients.FunTranslations, hc => hc.BaseAddress =
            new Uri(configuration[ApplicationConsts.HttpClients.FunTranslationsConfigKey]));

        return services;
    }
}