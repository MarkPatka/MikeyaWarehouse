using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Common.ValueObjects;

public readonly record struct BarCode
{
    public string Text { get; init; }
}
