using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Domain.Common.Extensions;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Domain.PalletAggregate.Entities;
using MikeyaWarehouse.Domain.PalletAggregate.Enumerations;
using MikeyaWarehouse.Wpf.Commands.Abstract;

namespace MikeyaWarehouse.Wpf.Commands;

public class LoadPalletDataCommand(IPalletsRepository pallets)
        : AsyncRelayCommand<LoadPalletDataCommandResult>
{
    private readonly IPalletsRepository _palletsRepository = pallets;

    public override Func<object?, Task<CommandResult<LoadPalletDataCommandResult>>> ExecuteCommand => LoadAllPallets;
    public override Predicate<object?>? CanExecuteCommand => null;
    public override Action<Exception>? ErrorHandler => LogError;


    private async Task<CommandResult<LoadPalletDataCommandResult>> LoadAllPallets(object? parameter = null)
    {
        try
        {
            var data = await _palletsRepository
                .GetFilteredAsync((p) => true, true);

            await LoadMockData(data.Where(p => p.ProductBoxes.Count == 0).ToList());

            LoadPalletDataCommandResult result = new(data);

            return new CommandResult<LoadPalletDataCommandResult>(result);
        }
        catch (Exception ex) 
        {
            ErrorHandler?.Invoke(ex);
            return new CommandResult<LoadPalletDataCommandResult>(ex);
        }
        
    }


    private async Task LoadMockData(List<Pallet> pallets)
    { 
        //var pallet_1 = Pallet.Create(PalletType.EURO);
        //var pallet_2 = Pallet.Create(PalletType.EURO);
        //var pallet_3 = Pallet.Create(PalletType.EURO);
        //var pallet_4 = Pallet.Create(PalletType.EURO);
        //var pallet_5 = Pallet.Create(PalletType.EURO);
        //var pallet_6 = Pallet.Create(PalletType.EURO);
        //var pallet_7 = Pallet.Create(PalletType.EURO);
        //var pallet_8 = Pallet.Create(PalletType.EURO);
        //var pallet_9 = Pallet.Create(PalletType.EURO);
        //var pallet_10 = Pallet.Create(PalletType.EURO);


        var box_1  = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 1, 1),  new DateOnly(2025, 1, 1),  new BarCode("BOX100001"), BoxStatus.RESERVED);
        var box_2  = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 2, 1),  new DateOnly(2025, 2, 1),  new BarCode("BOX100002"), BoxStatus.RESERVED);
        var box_3  = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 3, 1),  new DateOnly(2025, 3, 1),  new BarCode("BOX100003"), BoxStatus.RESERVED);
        var box_4  = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 4, 1),  new DateOnly(2025, 4, 1),  new BarCode("BOX100004"), BoxStatus.RESERVED);
        var box_5  = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 5, 1),  new DateOnly(2025, 5, 1),  new BarCode("BOX100005"), BoxStatus.RESERVED);
        var box_6  = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 6, 1),  new DateOnly(2025, 6, 1),  new BarCode("BOX100006"), BoxStatus.RESERVED);
        var box_7  = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 7, 1),  new DateOnly(2025, 7, 1),  new BarCode("BOX100007"), BoxStatus.RESERVED);
        var box_8  = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 8, 1),  new DateOnly(2025, 8, 1),  new BarCode("BOX100008"), BoxStatus.RESERVED);
        var box_9  = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 9, 1),  new DateOnly(2025, 9, 1),  new BarCode("BOX100009"), BoxStatus.RESERVED);
        var box_10 = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 10, 1), new DateOnly(2025, 10, 1), new BarCode("BOX100010"), BoxStatus.RESERVED);
        var box_11 = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 11, 1), new DateOnly(2025, 11, 1), new BarCode("BOX200001"), BoxStatus.RESERVED);
        var box_12 = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 12, 1), new DateOnly(2025, 12, 1), new BarCode("BOX200002"), BoxStatus.RESERVED);
        var box_13 = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 1, 2),  new DateOnly(2025, 1, 2),  new BarCode("BOX200003"), BoxStatus.RESERVED);
        var box_14 = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 2, 3),  new DateOnly(2025, 2, 3),  new BarCode("BOX200004"), BoxStatus.RESERVED);
        var box_15 = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 3, 4),  new DateOnly(2025, 3, 4),  new BarCode("BOX200005"), BoxStatus.RESERVED);
        var box_16 = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 4, 5),  new DateOnly(2025, 4, 5),  new BarCode("BOX200006"), BoxStatus.RESERVED);
        var box_17 = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 5, 6),  new DateOnly(2025, 5, 6),  new BarCode("BOX200007"), BoxStatus.RESERVED);
        var box_18 = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 6, 7),  new DateOnly(2025, 6, 7),  new BarCode("BOX200008"), BoxStatus.RESERVED);
        var box_19 = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 7, 8),  new DateOnly(2025, 7, 8),  new BarCode("BOX200009"), BoxStatus.RESERVED);
        var box_20 = ProductBox.Create(new Dimensions { Height = 20, Length = 20,  Width = 20, Weight = 20 }, new DateOnly(2026, 8, 9),  new DateOnly(2025, 8, 9),  new BarCode("BOX200010"), BoxStatus.RESERVED);

        //List<Pallet> pallets =
        //[
        //    pallet_1  ,
        //    pallet_2  ,
        //    pallet_3  ,
        //    pallet_4  ,
        //    pallet_5  ,
        //    pallet_6  ,
        //    pallet_7  ,
        //    pallet_8  ,
        //    pallet_9  ,
        //    pallet_10
        //];

        List<ProductBox> boxes =
        [
            box_1  ,
            box_2  ,
            box_3  ,
            box_4  ,
            box_5  ,
            box_6  ,
            box_7  ,
            box_8  ,
            box_9  ,
            box_10 ,
            box_11 ,
            box_12 ,
            box_13 ,
            box_14 ,
            box_15 ,
            box_16 ,
            box_17 ,
            box_18 ,
            box_19 ,
            box_20
        ];


        try
        {
            int boxIndex = 0;
            
            foreach (var pallet in pallets)
            {
                for (int i = 0; i < 2; i++)
                {
                    pallet.AddBox(boxes[boxIndex]);
                    boxIndex++;
                }
                await _palletsRepository.UpdateAsync(pallet);
            }
            await _palletsRepository.SaveAsync();
        }
        catch (Exception ex)
        {
            LogError(ex);
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
