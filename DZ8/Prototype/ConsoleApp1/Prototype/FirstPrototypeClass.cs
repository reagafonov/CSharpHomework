namespace Prototype;

/// <summary>
/// Первый класс
/// </summary>
public class FirstPrototypeClass:FirstSubClass, IMyClonable<FirstPrototypeClass>,
    ICloneable,IEquatable<FirstPrototypeClass>
{
    public FirstPrototypeClass()
    {
        
    }

    public FirstPrototypeClass(FirstPrototypeClass prototype)
        :base(prototype)
    {
        PrototypeDateTime = prototype.DataDateTime;
    }
    public DateTime PrototypeDateTime { get; set; }
    public FirstPrototypeClass Clone()
    {
        return new FirstPrototypeClass(this);
    }

    object ICloneable.Clone()
    {
        return Clone();
    }

    public bool Equals(FirstPrototypeClass? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return base.Equals(other) && PrototypeDateTime.Equals(other.PrototypeDateTime);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FirstPrototypeClass)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), PrototypeDateTime);
    }
}