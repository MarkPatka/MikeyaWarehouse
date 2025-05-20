using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.WarehouseAggregate.Enumerations;

public sealed class BufferZoneStatus(int id, string name, string? description = null)
    : Enumeration(id, name, description)
{
    public static readonly BufferZoneStatus LOADING   = new(1, nameof(LOADING), "Используется для погрузки.");
    public static readonly BufferZoneStatus UNLOADING = new(2, nameof(UNLOADING), "Используется для разгрузки.");
    public static readonly BufferZoneStatus FILLED    = new(3, nameof(FILLED), "Заполнена.");
    public static readonly BufferZoneStatus EMPTY     = new(4, nameof(EMPTY), "Свободна.");

}
