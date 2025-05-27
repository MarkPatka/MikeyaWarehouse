using Microsoft.EntityFrameworkCore;
using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Contracts.DTO;
using MikeyaWarehouse.Domain.ContractorsAggregate.Entities;
using MikeyaWarehouse.Wpf.Commands.Abstract;

namespace MikeyaWarehouse.Wpf.Commands;

public class LoadShipmentDataCommand(IContractorsRepository contractors)
        : AsyncRelayCommand<LoadShipmentDataCommandResult>
{
    private readonly IContractorsRepository _contractors = contractors;

    public override Func<object?, Task<CommandResult<LoadShipmentDataCommandResult>>> ExecuteCommand => LoadAllShipments;
    public override Predicate<object?>? CanExecuteCommand => null;
    public override Action<Exception>? ErrorHandler => LogError;


    private async Task<CommandResult<LoadShipmentDataCommandResult>> LoadAllShipments(object? parameter = null)
    {
        try
        {
            var shipments = await _contractors.GetShipmentsWithContractorsAsync();

            LoadShipmentDataCommandResult result = new(shipments);

            return new CommandResult<LoadShipmentDataCommandResult>(result);
        }
        catch (Exception ex) 
        {
            ErrorHandler?.Invoke(ex);
            return new CommandResult<LoadShipmentDataCommandResult>(ex);
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

public record LoadShipmentDataCommandResult(IEnumerable<ShipmentModel> Shipments);
