using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.ProductAggregate.ValueObjects;
using MikeyaWarehouse.Domain.WarehouseAggregate.Enumerations;
using MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.WarehouseAggregate.Entities;

public sealed class StorageBin : Entity<StorageBinId>
{
    public ProductId? StoredItem { get; }
    public int StoredCount { get; }

    public int Shell { get; }
    public int Number { get; }
    public BarCode BinBarCode { get; }
    public StorageBinStatus Status { get; } = StorageBinStatus.AVAILABLE;
    public Dimensions Dimensions { get; }
    public Dimensions AvailableToLoad { get; } // Free space + weight
    public LoadCapacity LoadCapacity { get; }

    private StorageBin(
        StorageBinId id,
        ProductId productId,
        int shell, 
        int number, 
        int storedItemCount,
        BarCode code, 
        StorageBinStatus status, 
        Dimensions dimensions, 
        Dimensions availableDimensions, 
        LoadCapacity capacity)
        : base(id)
    {
        StoredCount = storedItemCount;
        Number = number;
        StoredItem = productId;
        Shell = shell;
        StoredCount = number;
        BinBarCode = code;
        Status = status;
        Dimensions = dimensions;
        AvailableToLoad = availableDimensions;
        LoadCapacity = capacity;
    }

    public static StorageBin Create(
        int id, ProductId productId, int shell, int number, int storedItemCount,
        BarCode code, StorageBinStatus status,
        Dimensions dimensions, Dimensions availableDimensions,
        LoadCapacity capacity)
    {
        return new(StorageBinId.Create(id),
            productId, shell, number, storedItemCount, code, 
            status, dimensions, availableDimensions, capacity);
    }

}
