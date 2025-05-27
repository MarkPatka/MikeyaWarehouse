using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.Entities;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;
using MikeyaWarehouse.Domain.WarehouseAggregate.Enumerations;
using MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.WarehouseAggregate.Entities;

public sealed class StorageBin : Entity<StorageBinId>
{
    private readonly List<ProductBoxId> _storedBoxes = [];
    public IReadOnlyList<ProductBoxId> StoredBoxes => _storedBoxes.AsReadOnly();
    
    public PalletId? StoredPalletId { get; }
    
    public int StoredCount { get; }
    public int ShellLevel { get; }
    public int Number { get; }
    public BarCode BinBarCode { get; }
    public StorageBinStatus Status { get; } = StorageBinStatus.AVAILABLE;
    public Dimensions Dimensions { get; }
    public LoadCapacity LoadCapacity { get; }

#pragma warning disable CS8618
    private StorageBin() { }
#pragma warning restore CS8618

    private StorageBin(
        StorageBinId id,
        PalletId? palletId,
        int shell, 
        int number, 
        int storedItemCount,
        BarCode code, 
        StorageBinStatus status, 
        Dimensions dimensions, 
        LoadCapacity capacity)
        : base(id)
    {
        StoredPalletId = palletId;
        StoredCount = storedItemCount;
        Number = number;
        ShellLevel = shell;
        StoredCount = number;
        BinBarCode = code;
        Status = status;
        Dimensions = dimensions;
        LoadCapacity = capacity;
    }

    public static StorageBin Create(
        int id, PalletId? palletId, 
        int shell, int number, int storedItemCount,
        BarCode code, StorageBinStatus status,
        Dimensions dimensions, LoadCapacity capacity)
    {
        return new(StorageBinId.Create(id),
            palletId, shell, number, storedItemCount, code, 
            status, dimensions, capacity);
    }

}
