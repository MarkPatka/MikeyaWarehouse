using MikeyaWarehouse.Domain.Common.Entities;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate;
using System.Runtime.CompilerServices;

namespace MikeyaWarehouse.Domain.Common.Extensions;

public static class PalletExtensions
{
    public static DateOnly GetMaxExpireDate(this Pallet pallet)
    {
        if (pallet.ProductBoxes.Count == 0)
            return DateOnly.MinValue;

        DateOnly maxValue = pallet.ProductBoxes[0].Expire;
        for (int i = 1; i < pallet.ProductBoxes.Count; i++)
        {
            if (pallet.ProductBoxes[i].Expire > maxValue)
            {
                maxValue = pallet.ProductBoxes[i].Expire;
            }
        }
        return maxValue;
    }
    public static DateOnly GetMinExpireDate(this Pallet pallet)
    {
        if (pallet.ProductBoxes.Count == 0)
            return DateOnly.MinValue;

        DateOnly minValue = pallet.ProductBoxes[0].Expire;
        for (int i = 1; i < pallet.ProductBoxes.Count; i++)
        {
            if (pallet.ProductBoxes[i].Expire < minValue)
            {
                minValue = pallet.ProductBoxes[i].Expire;
            }
        }
        return minValue;
    }
    public static Dimensions GetPalletDimensions(this Pallet pallet)
    {
        var (length, width, height, weight) = pallet.Type.Id switch
        {
            1 => (
                GlobalConstants.FIN_PALLET_LENGTH,
                GlobalConstants.FIN_PALLET_WIDTH,
                GlobalConstants.FIN_PALLET_HEIGHT,
                GlobalConstants.FIN_PALLET_WEIGHT),
            2 => (
                GlobalConstants.EURO_PALLET_LENGTH,
                GlobalConstants.EURO_PALLET_WIDTH,
                GlobalConstants.EURO_PALLET_HEIGHT,
                GlobalConstants.EURO_PALLET_WEIGHT),
            3 => (
                GlobalConstants.EURO_STANDARD_PALLET_LENGTH,
                GlobalConstants.EURO_STANDARD_PALLET_WIDTH,
                GlobalConstants.EURO_STANDARD_PALLET_HEIGHT,
                GlobalConstants.EURO_STANDARD_PALLET_WEIGHT),
            _ => (0d, 0d, 0d, 0d)
        };

        if (pallet.ProductBoxes.Count == 0)
            return new Dimensions
            {
                Length = length,
                Width = width,
                Height = height,
                Weight = weight
            };

        var box = pallet.ProductBoxes[0];
        var boxesInRow = (length * width) / (box.Dimensions.Length * box.Dimensions.Width);
        var rowsCount = pallet.ProductBoxes.Count / boxesInRow;

        height += rowsCount == 0
            ? box.Dimensions.Height
            : box.Dimensions.Height * rowsCount;

        weight += pallet.ProductBoxes.Count * box.Dimensions.Weight;

        return new Dimensions
        {
            Height = height,
            Width = width,
            Weight = weight,
            Length = length
        };
    }


}
