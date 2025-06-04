using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MikeyaWarehouse.Infrastructure.Persistence.Configurations;
using MikeyaWarehouse.Wpf.Commands;
using MikeyaWarehouse.Wpf.Commands.Abstract;
using MikeyaWarehouse.Wpf.ViewModels.Implementations;
using MikeyaWarehouse.Wpf.ViewModels.Interfaces;
using System.IO;
using System.Threading.Channels;

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

        string host = Environment.GetEnvironmentVariable("PGHOST") 
            ?? throw new ArgumentNullException(nameof(Environment.GetEnvironmentVariable));

        int port =  Convert.ToInt32(Environment.GetEnvironmentVariable("PGPORT"));
        
        string user = Environment.GetEnvironmentVariable("PGUSER")
            ?? throw new ArgumentNullException(nameof(Environment.GetEnvironmentVariable));
        
        string pass = Environment.GetEnvironmentVariable("PGPASSWORD")
            ?? throw new ArgumentNullException(nameof(Environment.GetEnvironmentVariable));
        
        string name = Environment.GetEnvironmentVariable("PGDATABASE") 
            ?? throw new ArgumentNullException(nameof(Environment.GetEnvironmentVariable));

        services.Configure<DatabaseSettings>(options =>
        {
            options.DB_HOST = host;
            options.DB_PORT = port;
            options.DB_USER = user;
            options.DB_NAME = name;
            options.DB_PASSWORD = pass;
        });

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
            .AddTransient<GroupPaletsByRuleCommand>()
            .AddTransient<GetPalletsWithMaxExpireCommand>()
            ;

        return services;
    }

    private static IServiceCollection RegisterCommandFactory(this IServiceCollection services)
    {
        services.AddTransient<ICommandFactory, CommandFactory>();
        return services;
    }
}
