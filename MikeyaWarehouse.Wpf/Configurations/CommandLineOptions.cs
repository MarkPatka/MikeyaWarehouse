using CommandLine;

namespace MikeyaWarehouse.Wpf.Configurations;

/// <summary>
/// To add any launc logic in future. That is just a demo
/// </summary>
public sealed class CommandLineOptions
{
    [Option('i', "incognito", Required = false, HelpText = "Private mode")]
    public bool IsIncognitoModeEnabled { get; set; }

}
