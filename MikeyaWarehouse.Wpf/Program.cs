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
        // use in memory db if private mode for examle
        Parsed<CommandLineOptions> parserResult = Parser.Default
            .ParseArguments<CommandLineOptions>(args)
            .Cast<Parsed<CommandLineOptions>>();


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
            var app = new Application();
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
}

