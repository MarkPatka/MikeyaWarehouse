using CommandLine;

namespace MikeyaWarehouse.Wpf.Configurations;

/// <summary>
/// To add any launc logic in future. That is just a demo
/// </summary>
public sealed class CommandLineOptions
{
    [Option('c', "console", Required = false, HelpText = "Open in console mode")]
    public bool IsConsoleModeEnabled { get; set; }

}