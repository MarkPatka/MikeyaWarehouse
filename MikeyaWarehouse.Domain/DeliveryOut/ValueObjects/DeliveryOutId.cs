using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.OutcomingDelivery.ValueObjects;

public sealed class DeliveryOutId : ValueObject
{
    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
