using Fluid;
using Microsoft.Extensions.DependencyInjection;
using Whitelabel.Business.Helpers.TemplateBuilder;
using Whitelabel.Business.Services.WhiteLabel;

namespace Whitelabel.Business;

public static class DependencyInjection
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddSignalR().AddStackExchangeRedis("localhost:6379");
        services.AddSingleton<FluidParser>();
        services.AddScoped<ITemplateBuilder, TemplateBuilder>();
        services.AddScoped<IWhiteLabelService,WhiteLabelService>();
        return services;
    }
}