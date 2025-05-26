using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Wpf.Commands.Abstract;

public class CommandStatus(int id, string name, string? description = null)
    : Enumeration(id, name, description)
{
    public static readonly CommandStatus DEFAULT   = new(0, "Default", "The command created.");
    public static readonly CommandStatus EXECUTING = new(1, "InProgress", "The command is currently executing");
    public static readonly CommandStatus SUCCESS   = new(2, "Succeeded", "The command is completed successfully");
    public static readonly CommandStatus ERROR     = new(3, "Error", "The command completed with an error");
    public static readonly CommandStatus CANCELED  = new(4, "Canceled", "The command execution was canceled");

}
