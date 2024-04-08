using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Whitelabel.Core.Settings;
using Whitelabel.Infrastructure.Context;
using Whitelabel.Infrastructure.Repositories;
using Whitelabel.Infrastructure.Repositories.Base;
using Whitelabel.Infrastructure.UnitOfWork;

namespace Whitelabel.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceProvider = services.BuildServiceProvider();
        var appSettings = serviceProvider.GetRequiredService<AppSettings>();
        
        services.AddDbContextPool<AppDbContext>(options => options.UseNpgsql(appSettings.PostgresqlSetting.ConnectionString));
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddRepositories();

        return services;
    }
}