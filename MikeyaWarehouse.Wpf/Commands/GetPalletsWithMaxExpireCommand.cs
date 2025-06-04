using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Application.Common.Services;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Wpf.Commands.Abstract;

namespace MikeyaWarehouse.Wpf.Commands;

public class GetPalletsWithMaxExpireCommand(IPalletsRepository pallets, IPalletsManagementService palletsManager)
    : AsyncRelayCommand<GetMaxExpiresPalletsCommandResult>
{
    private readonly IPalletsRepository _pallets = pallets;
    private readonly IPalletsManagementService _palletManager = palletsManager;

    public override Func<object?, Task<CommandResult<GetMaxExpiresPalletsCommandResult>>> ExecuteCommand => GetPallets;
    public override Predicate<object?>? CanExecuteCommand => null;
    public override Action<Exception>? ErrorHandler => LogError;


    private async Task<CommandResult<GetMaxExpiresPalletsCommandResult>> GetPallets(object? parameter = null)
    {
        try
        {
            var data = await _pallets
                .GetFilteredAsync((p) => true);

            var res = _palletManager
                .SortPalletsByExpirationDate([.. data]);

            GetMaxExpiresPalletsCommandResult result = new(res);

            return new CommandResult<GetMaxExpiresPalletsCommandResult>(result);
        }
        catch (Exception ex)
        {
            ErrorHandler?.Invoke(ex);
            return new CommandResult<GetMaxExpiresPalletsCommandResult>(ex);
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

public record GetMaxExpiresPalletsCommandResult(Pallet[] Pallets);


