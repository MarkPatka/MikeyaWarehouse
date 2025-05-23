using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MikeyaWarehouse.Application;
using MikeyaWarehouse.Infrastructure;
using MikeyaWarehouse.Infrastructure.Persistence.Configurations;
using MikeyaWarehouse.Wpf.Configurations;
using MikeyaWarehouse.Wpf.ViewModels.Interfaces;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;

namespace MikeyaWarehouse.Wpf;

internal class Program
{
    private const int TimeoutSeconds = 3;
    
    [STAThread]
    public static void Main(string[] args)
    {
        //Parsed<CommandLineOptions> parserResult = Parser.Default
        //    .ParseArguments<CommandLineOptions>(args)
        //    .Cast<Parsed<CommandLineOptions>>();
        
        EnvLoader.Load();

        //if (parserResult.Value.IsConsoleModeEnabled) 
        //    LaunchConsoleMode();

        using var mutex = new Mutex(true, Assembly.GetExecutingAssembly().FullName);
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
                SubscribeToDomainEvents();
                RunWpfApplication(host);
            }
        }
        finally
        {
            mutex.ReleaseMutex();
            FreeConsole();
        }
    }

    private static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services
                    .AddPresentation()
                    .AddApplication()
                    .AddInfrastructure();
            });
    private static void SubscribeToDomainEvents()
    {
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            Exception ex = (Exception)args.ExceptionObject;

            MessageBox.Show(
                $"An unhandled exception occurred: {ex.Message}",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        };

        AppDomain.CurrentDomain.ProcessExit += (s, e) => FreeConsole();
    }
    private static void RunWpfApplication(IHost host)
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
    private static void LaunchConsoleMode()
    {
        AllocConsole();

        MessageBox.Show("You have console mode enabled");
        Task.Run(() =>
        {
            while (true)
            {
                string? input = Console.ReadLine();
                HandleConsoleCommand(input);
            }
        });
    }
    private static void HandleConsoleCommand(string? input)
    {
        // TODO:
        Console.WriteLine($"You`ve entered: {input}");
    }


    
    [DllImport("Kernel32")]
    public static extern void AllocConsole();
    [DllImport("Kernel32", SetLastError = true)]
    public static extern void FreeConsole();
}

