namespace MikeyaWarehouse.Domain.Common.Abstract;

public abstract class AggregateRoot<Tid> 
    : Entity<Tid> where Tid : notnull
{
    protected AggregateRoot(Tid id) : base(id) { }
    protected AggregateRoot() { }
}
