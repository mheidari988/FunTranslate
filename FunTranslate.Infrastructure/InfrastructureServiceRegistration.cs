using FunTranslate.Application;
using FunTranslate.Application.Contracts.Infrastructure;
using FunTranslate.Infrastructure.ExternalTranslation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FunTranslate.Infrastructure;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IExternalTranslationService, FunTranslationService>();
        services.AddHttpClient(ApplicationConsts.HttpClients.FunTranslations, hc => hc.BaseAddress =
            new Uri(configuration[ApplicationConsts.HttpClients.FunTranslationsConfigKey]));

        return services;
    }
}