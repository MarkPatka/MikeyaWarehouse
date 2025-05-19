using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.Warehouse.ValueObjects;

namespace MikeyaWarehouse.Domain.Warehouse.Entities;

public sealed class StorageRack : Entity<StorageRackId>
{
    //TODO: storage section ... and storage bin 


    public int Levels { get; }
    public LoadCapacity LoadCapacity { get; }


}
