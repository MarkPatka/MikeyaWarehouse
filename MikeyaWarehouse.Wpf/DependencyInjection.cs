using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MikeyaWarehouse.Infrastructure.Persistence.Configurations;
using MikeyaWarehouse.Wpf.Commands;
using MikeyaWarehouse.Wpf.Commands.Abstract;
using MikeyaWarehouse.Wpf.ViewModels.Implementations;
using MikeyaWarehouse.Wpf.ViewModels.Interfaces;
using System.IO;
using System.Windows.Input;

namespace MikeyaWarehouse.Wpf;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services
            .AddConfiguration()
            .RegisterCommands()
            .RegisterCommandFactory()
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

    private static IServiceCollection RegisterCommands(this IServiceCollection services)
    {
        services
            .AddTransient<LoadShipmentDataCommand>()
            .AddTransient<LoadProductDataCommand>()
            .AddTransient<LoadPalletDataCommand>()
            ;

        return services;
    }

    private static IServiceCollection RegisterCommandFactory(this IServiceCollection services)
    {
        services.AddTransient<ICommandFactory, CommandFactory>();
        return services;
    }
}
