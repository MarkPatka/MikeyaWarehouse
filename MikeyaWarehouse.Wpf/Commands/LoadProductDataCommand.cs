using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Domain.PalletAggregate.Entities;
using MikeyaWarehouse.Wpf.Commands.Abstract;

namespace MikeyaWarehouse.Wpf.Commands;

public class LoadProductDataCommand(IPalletsRepository pallets)
        : AsyncRelayCommand<LoadProductDataCommandResult>
{
    private readonly IPalletsRepository _pallets = pallets;

    public override Func<object?, Task<CommandResult<LoadProductDataCommandResult>>> ExecuteCommand => LoadAllProducts;
    public override Predicate<object?>? CanExecuteCommand => null;
    public override Action<Exception>? ErrorHandler => LogError;


    private async Task<CommandResult<LoadProductDataCommandResult>> LoadAllProducts(object? parameter = null)
    {
        try
        {
            var pallets = await _pallets
                .GetFilteredAsync((p) => true);

            var products = pallets
                .SelectMany(pallets => pallets.ProductBoxes
                    .SelectMany(boxes => boxes.Products));

            LoadProductDataCommandResult result = new(products);

            return new CommandResult<LoadProductDataCommandResult>(result);
        }
        catch (Exception ex)
        {
            ErrorHandler?.Invoke(ex);
            return new CommandResult<LoadProductDataCommandResult>(ex);
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

public record LoadProductDataCommandResult(IEnumerable<Product> Products);

