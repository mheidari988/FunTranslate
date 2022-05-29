using FunTranslate.Application.Contracts.Persistence.Dapper;
using FunTranslate.Persistence.Dapper.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FunTranslate.Persistence.Dapper;
public static class DapperServiceRegistration
{
    public static IServiceCollection AddDapperServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISqlDataAccess, DapperSqlDataAccess>();
        services.AddScoped<IFunTranslationDataAccess, FunTranslationDataAccess>();
        return services;
    }
}
