using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MikeyaWarehouse.Wpf.ViewModels.Implementations;
using MikeyaWarehouse.Wpf.ViewModels.Interfaces;
using System.IO;

namespace MikeyaWarehouse.Wpf;

public static class DependencyInjection
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        services.AddSingleton<IConfiguration>(configuration);
        return services;
    }

    public static IServiceCollection RegisterViews(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        return services;
    }
    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddSingleton<IMainViewModel, MainViewModel>();
        return services;
    }
}
