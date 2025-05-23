using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.PalletAggregate.Enumerations;

public sealed class BoxStatus(int id, string name, string? description = null)
    : Enumeration(id, name, description)
{
    public static readonly BoxStatus DAMAGED = new(1, nameof(DAMAGED), "Брак");
    public static readonly BoxStatus FULL = new(2, nameof(FULL), "Полная");
    public static readonly BoxStatus RESERVED = new(3, nameof(RESERVED), "Резерв");
    public static readonly BoxStatus EMPTY = new(3, nameof(EMPTY), "Пустая");
}
