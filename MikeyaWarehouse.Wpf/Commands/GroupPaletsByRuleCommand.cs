using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Application.Common.Services;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;
using MikeyaWarehouse.Wpf.Commands.Abstract;

namespace MikeyaWarehouse.Wpf.Commands;

public class GroupPaletsByRuleCommand(IPalletsRepository pallets, IPalletsManagementService palletsManager)
    : AsyncRelayCommand<GroupPalletsCommandResult>
{
    private readonly IPalletsRepository _pallets = pallets;
    private readonly IPalletsManagementService _palletManager = palletsManager;

    public override Func<object?, Task<CommandResult<GroupPalletsCommandResult>>> ExecuteCommand => GroupPallets;
    public override Predicate<object?>? CanExecuteCommand => null;
    public override Action<Exception>? ErrorHandler => LogError;


    private async Task<CommandResult<GroupPalletsCommandResult>> GroupPallets(object? parameter = null)
    {
        try
        {
            var data = await _pallets
                .GetFilteredAsync((p) => true);

            var res = _palletManager
                .GroupPalletsByExpirationDate([.. data]);

            GroupPalletsCommandResult result = new(res);

            return new CommandResult<GroupPalletsCommandResult>(result);
        }
        catch (Exception ex)
        {
            ErrorHandler?.Invoke(ex);
            return new CommandResult<GroupPalletsCommandResult>(ex);
        }

    }

    private void LogError(Exception message)
    {
        Console.WriteLine(message.Message);
        //_logger.LogError(message, 
        //    "Error handling message of type {messageType}", 
        //    message.GetType().Name);
    }
}

public record GroupPalletsCommandResult(Dictionary<DateOnly, List<Pallet>> Pallets);
