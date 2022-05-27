using FunTranslate.Application;
using FunTranslate.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FunTranslate.Persistence;
public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FunTranslateDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString(ApplicationConsts.ConnectionStrings.FunTranslateDbConnectionString));
        });

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IFunTranslationRepository, FunTranslationRepository>();

        return services;
    }
}
