using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        // its for migrations.
        // ef migrations couldn`t get an acces to IConfiguration for a some reason
        // thats why the cs is hardcoded
        services.AddDbContext<MikeyaWarehouseDbContext>((provider, options) =>
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=MikeyaWarehouseDb;Username=mikeyaUser;Password=mikeyA1234",
                cfg => cfg.EnableRetryOnFailure(2));

        }, ServiceLifetime.Scoped);


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


