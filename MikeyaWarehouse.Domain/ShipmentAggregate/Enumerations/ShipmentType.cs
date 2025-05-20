using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.ShipmentAggregate.Enumerations;

public sealed class ShipmentType(int id, string name, string? description = null)
    : Enumeration(id, name, description)
{
    public static readonly ShipmentType INCOMING = new(1, nameof(INCOMING), "Входящая поставка");
    public static readonly ShipmentType OUTGOING = new(2, nameof(OUTGOING), "Исходящая поставка");
}
