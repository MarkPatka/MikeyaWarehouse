using Microsoft.Extensions.Logging;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Wpf.Commands.Abstract;
using System;

namespace MikeyaWarehouse.Wpf.Commands;

public class LoadDataCommand 
    : AsyncRelayCommand<LoadDataCommandResult>
{
    private readonly ILogger _logger;

    public LoadDataCommand(ILogger logger)
    {
        _logger = logger;
    }

    public override Func<object?, Task> ExecuteCommand => throw new NotImplementedException();
    public override Predicate<object?>? CanExecuteCommand => throw new NotImplementedException();
    public override Action<Exception>? ErrorHandler => null;





    private void LogError(Exception message)
    {
        _logger.LogError(message, 
            "Error handling message of type {messageType}", 
            message.GetType().Name);
    }
}

public record LoadDataCommandResult(IEnumerable<Pallet> Pallets);
