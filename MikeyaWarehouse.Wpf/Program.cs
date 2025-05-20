using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MikeyaWarehouse.Wpf.Configurations;
using MikeyaWarehouse.Wpf.ViewModels.Interfaces;
using System.Reflection;
using System.Windows;

namespace MikeyaWarehouse.Wpf;

internal class Program
{
    private const int TimeoutSeconds = 3;

    [STAThread]
    public static void Main(string[] args)
    {
        EnvLoader.Load();

        using var mutex = new Mutex(true, Assembly.GetExecutingAssembly().FullName, out bool createdNew);
        try
        {
            if (!mutex.WaitOne(TimeSpan.FromSeconds(TimeoutSeconds), true))
            {
                MessageBox.Show(
                    $"Application is already running",
                    "Warning",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else
            {
                using IHost host = CreateHostBuilder().Build();
                SubscribeToDomainUnhandledExceptions();
                string s = GetDatabaseConnectionEvironmentCredentials();
                RunApplication(host);
            }
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }

    private static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services
                    .AddConfiguration()
                    .RegisterViewModels()
                    .RegisterViews();
            });
    private static void SubscribeToDomainUnhandledExceptions() =>
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            Exception ex = (Exception)args.ExceptionObject;

            MessageBox.Show(
                $"An unhandled exception occurred: {ex.Message}",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        };

    private static void RunApplication(IHost host)
    {
        try
        {
            var app = new System.Windows.Application();
            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.DataContext = host.Services.GetRequiredService<IMainViewModel>();
            app.Run(mainWindow);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Program error occurred: {ex.Message}", 
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private static string GetDatabaseConnectionEvironmentCredentials()
    {
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
        var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "appdb";
        var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "password";

        return
            $"Host={dbHost};" +
            $"Port=5432;" +
            $"Database={dbName};" +
            $"Username={dbUser};" +
            $"Password={dbPassword}";
    }
}

