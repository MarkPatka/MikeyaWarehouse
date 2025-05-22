using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MikeyaWarehouse.Infrastructure.Persistence.Configurations;
using MikeyaWarehouse.Wpf.ViewModels.Implementations;
using MikeyaWarehouse.Wpf.ViewModels.Interfaces;
using System.IO;

namespace MikeyaWarehouse.Wpf;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services
            .AddConfiguration()
            .RegisterViewModels()
            .RegisterViews();
    
        return services;
    }


    private static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        services.AddSingleton<IConfiguration>(configuration);

        services.Configure<DatabaseSettings>(
            configuration.GetRequiredSection("Database"));

        return services;
    }

    private static IServiceCollection RegisterViews(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        return services;
    }
    private static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddSingleton<IMainViewModel, MainViewModel>();
        return services;
    }
}
