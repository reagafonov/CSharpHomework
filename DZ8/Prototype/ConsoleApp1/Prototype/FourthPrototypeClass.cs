namespace Prototype;

/// <summary>
/// Четвертый класс
/// </summary>
public class FourthPrototypeClass:FourthSubClass, IMyClonable<FourthPrototypeClass>,
    ICloneable,IEquatable<FourthPrototypeClass>
{
    public FourthPrototypeClass()
    {}

    public FourthPrototypeClass(FourthPrototypeClass prototype)
        :base(prototype)
    {
        Dictionary = prototype.Dictionary
            .ToDictionary(x => x.Key, x => x.Value);
    }
    public Dictionary<string,string> Dictionary { get; set; }
    public FourthPrototypeClass Clone()
    {
        return new FourthPrototypeClass(this);
    }

    object ICloneable.Clone()
    {
        return Clone();
    }

    public bool Equals(FourthPrototypeClass? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return base.Equals(other) && Dictionary.Equals(other.Dictionary);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FourthPrototypeClass)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Dictionary);
    }
}