using Microsoft.Extensions.DependencyInjection;
using Whitelabel.Infrastructure.Repositories.Abstract;
using Whitelabel.Infrastructure.Repositories.Concrete;

namespace Whitelabel.Infrastructure.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWhiteLabelRepository, WhiteLabelRepository>();

        return services;
    }
}