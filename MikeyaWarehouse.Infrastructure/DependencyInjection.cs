using Microsoft.Extensions.DependencyInjection;

namespace MikeyaWarehouse.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .RegisterServices()
            ;

        return services;
    }
    
    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        
        return services;
    }

}
