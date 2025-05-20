using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.Product;
using MikeyaWarehouse.Domain.Warehouse.Enumerations;
using MikeyaWarehouse.Domain.Warehouse.ValueObjects;

namespace MikeyaWarehouse.Domain.Warehouse.Entities;

public sealed class StorageBin : Entity<StorageBinId>
{
    private readonly List<Product.Product> _items = [];

    public int Shell { get; }
    public int Number { get; }
    public BarCode BinBarCode { get; }
    public StorageBinStatus Status { get; } = StorageBinStatus.AVAILABLE;
    public Dimensions Dimensions { get; }
    public Dimensions AvailableToLoad { get; } // Free space + weight
    public LoadCapacity LoadCapacity { get; }


    private StorageBin(StorageBinId id, 
        int shell, 
        int number, 
        BarCode code, 
        StorageBinStatus status, 
        Dimensions dimensions, 
        Dimensions availableDimensions, 
        LoadCapacity capacity)
        : base(id)
    {
        Shell = shell;
        Number = number;
        BinBarCode = code;
        Status = status;
        Dimensions = dimensions;
        AvailableToLoad = availableDimensions;
        LoadCapacity = capacity;
    }

    public static StorageBin Create(
        int id, int shell, int number,
        BarCode code, StorageBinStatus status,
        Dimensions dimensions, Dimensions availableDimensions,
        LoadCapacity capacity)
    {
        return new(StorageBinId.Create(id),  
            shell, number, code, status, dimensions, availableDimensions, capacity);
    }

}
