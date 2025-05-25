using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Application.Common.Services;
using MikeyaWarehouse.Infrastructure.Persistence;
using MikeyaWarehouse.Infrastructure.Persistence.Configurations;
using MikeyaWarehouse.Infrastructure.Persistence.Repositories;
using MikeyaWarehouse.Infrastructure.Services;

namespace MikeyaWarehouse.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .RegisterDbContext()
            .RegisterRepositories()
            .RegisterServices()
            ;

        return services;
    }

    private static IServiceCollection RegisterDbContext(this IServiceCollection services)
    {
        services.AddDbContextFactory<MikeyaWarehouseDbContext>((provider, options) =>
        {
            var dbSettings = provider
                .GetRequiredService<IOptions<DatabaseSettings>>().Value;

            options.UseNpgsql(dbSettings.ConnectionString,
                cfg => cfg.EnableRetryOnFailure(2));

        }, ServiceLifetime.Scoped);

        return services;
    }

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {

        services
            .AddScoped<IContractorsRepository, ContractorsRepository>()
            .AddScoped<IPalletsRepository, PalletsRepository>()
            .AddScoped<IProductsRepository, ProductsRepository>()
            .AddScoped<IShipmentsRepository, ShipmentsRepository>()
            .AddScoped<IWarehousesRepository, WarehousesRepository>();
        
        return services;
    }


    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        
        services
            .AddScoped<IPalletsManagementService, PalletsManagementService>();

        return services;
    }

}
