using System.Reflection;

namespace MikeyaWarehouse.Domain.Common.Abstract;

public abstract class Enumeration 
    : IComparable, IEquatable<Enumeration>
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; } = null;

    protected Enumeration(int id, string name, string? description = null) =>
        (Id, Name, Description) = (id, name, description);
    
    public static IEnumerable<T> GetAll<T>() 
        where T : Enumeration =>
        typeof(T).GetFields(
            BindingFlags.Public |
            BindingFlags.Static |
            BindingFlags.DeclaredOnly)
        .Select(f => f.GetValue(null))
        .Cast<T>();

    private static T Parse<T, K>(K value, Func<T, bool> predicate)
            where T : Enumeration
    {
        return GetAll<T>().FirstOrDefault(predicate)
            ?? throw new ApplicationException($"{value} is not valid item for the type: {typeof(T).Name}");
    }
    public static T GetFromId<T>(int id)
        where T : Enumeration
    {
        return Parse<T, int>(id, i => i.Id == id);
    }
    public int CompareTo(object? obj)
    {
        if (obj is null) return 1;
        return Id.CompareTo(((Enumeration)obj).Id);
    }
    public bool Equals(Enumeration? other)
    {
        if (other is null) return false;
        return Id.Equals(other.Id);
    }
    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration other || obj is null)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(other.Id);

        return typeMatches && valueMatches;
    }
    public override int GetHashCode() => 
        Id.GetHashCode();
    public override string ToString() => 
        Name;
}
