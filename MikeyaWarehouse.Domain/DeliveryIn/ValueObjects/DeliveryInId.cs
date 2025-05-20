using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Delivery.ValueObjects;

public sealed class DeliveryInId : ValueObject
{
    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
