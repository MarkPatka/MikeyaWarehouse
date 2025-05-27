using Microsoft.Extensions.Logging;
using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Wpf.Commands.Abstract;

namespace MikeyaWarehouse.Wpf.Commands;

public class LoadPalletDataCommand 
    : AsyncRelayCommand<LoadPalletDataCommandResult>
{
    private readonly IPalletsRepository _pallets;

    public LoadPalletDataCommand(
        IPalletsRepository pallets)
    {
        _pallets = pallets;
    }

    public override Func<object?, Task<CommandResult<LoadPalletDataCommandResult>>> ExecuteCommand => LoadAllPallets;
    public override Predicate<object?>? CanExecuteCommand => null;
    public override Action<Exception>? ErrorHandler => LogError;


    private async Task<CommandResult<LoadPalletDataCommandResult>> LoadAllPallets(object? parameter = null)
    {
        try
        {
            var data = await _pallets
                .GetFilteredAsync((p) => true);

            LoadPalletDataCommandResult result = new(data);

            return new CommandResult<LoadPalletDataCommandResult>(result);
        }
        catch (Exception ex) 
        {
            ErrorHandler?.Invoke(ex);
            return new CommandResult<LoadPalletDataCommandResult>(ex);
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

public record LoadPalletDataCommandResult(IEnumerable<Pallet> Pallets);
