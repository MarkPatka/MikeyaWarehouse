using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Domain.PalletAggregate.Entities;
using MikeyaWarehouse.Domain.PalletAggregate.Enumerations;
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
                Pallet.Create(PalletType.EURO)
            ];

        var boxDimensions = new Dimensions
        {
            Height = 20,
            Length = 20,
            Width = 20,
            Weight = 20
        };

        List<ProductBox> boxes =
            [
                ProductBox.Create(
                    boxDimensions,
                    new DateOnly(2025, 06, 30),
                    new DateOnly(2024, 06, 30),
                    new BarCode("BRX100001"),
                    BoxStatus.EMPTY),


                ProductBox.Create(
                    boxDimensions,
                    new DateOnly(2025, 07, 30),
                    new DateOnly(2024, 07, 30),
                    new BarCode("BRX100001"),
                    BoxStatus.EMPTY),


                ProductBox.Create(
                    boxDimensions,
                    new DateOnly(2025, 08, 30),
                    new DateOnly(2024, 08, 30),
                    new BarCode("BRX100001"),
                    BoxStatus.EMPTY),
            ];

        
        var palletRepositoryMock = new Mock<IPalletsRepository>();

        // TODO: Change ownded entities data from readonly only for a test purposes


        // Act

        // Assert
    }
}
