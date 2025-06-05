using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Application.Common.Services;
using MikeyaWarehouse.Domain.Common.Extensions;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Domain.PalletAggregate.Entities;
using MikeyaWarehouse.Domain.PalletAggregate.Enumerations;
using MikeyaWarehouse.Infrastructure.Services;
using Moq;

namespace MikeyaWarehouse.Application.UnitTests.Services;

public class PalletsManagementServiceTests
{
    [Fact]
    public void SortByExpirationDate()
    {
        // Arrange
        List<Pallet> pallets =
        [
            Pallet.Create(PalletType.EURO),
            Pallet.Create(PalletType.EURO),
            Pallet.Create(PalletType.EURO),
            Pallet.Create(PalletType.EURO),
            Pallet.Create(PalletType.EURO),
            Pallet.Create(PalletType.EURO)
        ];


        List<ProductBox> boxes =
        [
            /// FOR GROUP 1
            // PALLET 1
            ProductBox.Create(
                new Dimensions
                {
                    Height = 20,
                    Length = 20,
                    Width = 20,
                    Weight = 20
                },
                new DateOnly(2025, 06, 30),
                new DateOnly(2024, 06, 30),
                new BarCode("BRX100001"),
                BoxStatus.FULL),
            
            ProductBox.Create(
                new Dimensions
                {
                    Height = 20,
                    Length = 20,
                    Width = 20,
                    Weight = 20
                },
                new DateOnly(2025, 06, 30),
                new DateOnly(2024, 06, 30),
                new BarCode("BRX100002"),
                BoxStatus.FULL),
            
            // PALLET 2
            ProductBox.Create(
                new Dimensions
                {
                    Height = 20,
                    Length = 20,
                    Width = 20,
                    Weight = 30
                },
                new DateOnly(2025, 06, 30),
                new DateOnly(2024, 06, 30),
                new BarCode("BRX100003"),
                BoxStatus.FULL),
            
            ProductBox.Create(
                new Dimensions
                {
                    Height = 20,
                    Length = 20,
                    Width = 20,
                    Weight = 30
                },
                new DateOnly(2025, 06, 30),
                new DateOnly(2024, 06, 30),
                new BarCode("BRX100004"),
                BoxStatus.FULL),

            /// FOR GROUP 2
            // PALLET 3
            ProductBox.Create(
                new Dimensions
                {
                    Height = 20,
                    Length = 20,
                    Width = 20,
                    Weight = 40
                },
                new DateOnly(2025, 07, 30),
                new DateOnly(2024, 07, 30),
                new BarCode("BRX100005"),
                BoxStatus.FULL),

            ProductBox.Create(
                new Dimensions
                {
                    Height = 20,
                    Length = 20,
                    Width = 20,
                    Weight = 40
                },
                new DateOnly(2025, 07, 30),
                new DateOnly(2024, 07, 30),
                new BarCode("BRX100006"),
                BoxStatus.FULL),

            // PALLET 4
            ProductBox.Create(
                new Dimensions
                {
                    Height = 20,
                    Length = 20,
                    Width = 20,
                    Weight = 50
                },
                new DateOnly(2025, 07, 30),
                new DateOnly(2024, 07, 30),
                new BarCode("BRX100007"),
                BoxStatus.FULL),

            ProductBox.Create(
                new Dimensions
                {
                    Height = 20,
                    Length = 20,
                    Width = 20,
                    Weight = 50
                },
                new DateOnly(2025, 07, 30),
                new DateOnly(2024, 07, 30),
                new BarCode("BRX100008"),
                BoxStatus.FULL),

            /// FOR GROUP 3
            // FOR PALLET 5
            ProductBox.Create(
                new Dimensions
                {
                    Height = 20,
                    Length = 20,
                    Width = 20,
                    Weight = 60
                },
                new DateOnly(2025, 08, 30),
                new DateOnly(2024, 08, 30),
                new BarCode("BRX100009"),
                BoxStatus.FULL),

            ProductBox.Create(
                new Dimensions
                {
                    Height = 20,
                    Length = 20,
                    Width = 20,
                    Weight = 60
                },
                new DateOnly(2025, 08, 30),
                new DateOnly(2024, 08, 30),
                new BarCode("BRX200001"),
                BoxStatus.FULL),

            // FOR PALLET 6
            ProductBox.Create(
                new Dimensions
                {
                    Height = 20,
                    Length = 20,
                    Width = 20,
                    Weight = 70
                },
                new DateOnly(2025, 08, 30),
                new DateOnly(2024, 08, 30),
                new BarCode("BRX200002"),
                BoxStatus.FULL),

            ProductBox.Create(
                new Dimensions
                {
                    Height = 20,
                    Length = 20,
                    Width = 20,
                    Weight = 70
                },
                new DateOnly(2025, 08, 30),
                new DateOnly(2024, 08, 30),
                new BarCode("BRX200002"),
                BoxStatus.FULL),
        ];

        int index = 0;
        foreach (var pallet in pallets)
        {
            for (int i = 0; i < 2; i++)
            {
                pallet.AddBox(boxes[index++]);
            }
        }

        var palletManager = new PalletsManagementService();

        // Act
        var result = palletManager
            .GroupPalletsByExpirationDate([.. pallets], "ASC");

        // Assert
        var expectKeys = new List<DateOnly>
        {
            new(2025, 06, 30),
            new(2025, 07, 30),
            new(2025, 08, 30),
        };
        var factKeys = result.Keys.ToList();

        var expectGroups = new List<List<double>>
        {
            //Pallet.Weight + Box1.Weight + Box2.Weight
            new() 
            { 
                25 + 20 + 20, // pallets[0].GetPalletWhithBoxDimensions().Weight,
                25 + 30 + 30  // pallets[1].GetPalletWhithBoxDimensions().Weight
            },
            new()
            {
                25 + 40 + 40,
                25 + 50 + 50,
            },
            new()
            {
                25 + 60 + 60,
                25 + 70 + 70
            },
        };

        var factGroups = result
            .Select(x => x.Value
                .Select(v => v.GetPalletWhithBoxDimensions().Weight)
                .ToList())
            .ToList();


        Assert.Equal(expectKeys, factKeys);
        Assert.Equal(expectGroups, factGroups);
    }
}
