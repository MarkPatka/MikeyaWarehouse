using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.WarehouseAggregate.Enumerations;
using MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.WarehouseAggregate.Entities;

public sealed class Ramp : Entity<RampId>
{
    public char Gate { get; }
    public RampStatus Status { get; } = RampStatus.OPEN;

    private Ramp(RampId id, char gate, RampStatus status)
        : base(id)
    {
        Gate = gate;
        Status = status;
    }

    public static Ramp Create(int id, char gate, RampStatus status)
    {
        return new(RampId.Create(id), gate, status);
    }
}
