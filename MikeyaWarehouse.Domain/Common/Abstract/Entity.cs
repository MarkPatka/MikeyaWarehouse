namespace MikeyaWarehouse.Domain.Common.Abstract;

public abstract class Entity<Tid> :
    IEquatable<Entity<Tid>>
    where Tid : notnull
{
    public Tid Id { get; protected set; }

#pragma warning disable CS8618 
    protected Entity() { }
#pragma warning restore CS8618 

    protected Entity(Tid id) => 
        Id = id;

    public bool Equals(Entity<Tid>? other) =>
        Equals((object?)other);

    public override bool Equals(object? obj) =>
        obj is Entity<Tid> entity && Id.Equals(entity.Id);

    public static bool operator ==(Entity<Tid> left, Entity<Tid> right) =>
        Equals(left, right);
    
    public static bool operator !=(Entity<Tid> left, Entity<Tid> right) =>
        !Equals(left, right);
    
    public override int GetHashCode() =>
        Id.GetHashCode();
}
