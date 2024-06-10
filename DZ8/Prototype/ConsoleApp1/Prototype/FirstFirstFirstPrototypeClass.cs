namespace Prototype;

/// <summary>
/// Первый класс
/// Наследуется от базового
/// </summary>
public class FirstFirstFirstPrototypeClass:FirstFirstSubClass, IMyClonable<FirstFirstFirstPrototypeClass>,
    ICloneable,IEquatable<FirstFirstFirstPrototypeClass>
{
    public FirstFirstFirstPrototypeClass()
    {
        
    }

    public FirstFirstFirstPrototypeClass(FirstFirstFirstPrototypeClass prototype)
        :base(prototype)
    {
        PrototypeDateTime = prototype.PrototypeDateTime;
    }
    public DateTime PrototypeDateTime { get; set; }
    public override FirstFirstFirstPrototypeClass MyClone()
    {
        return new FirstFirstFirstPrototypeClass(this);
    }

    object ICloneable.Clone()
    {
        return MyClone();
    }

    public bool Equals(FirstFirstFirstPrototypeClass? other)
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
        return base.Equals((FirstFirstFirstPrototypeClass)obj) && PrototypeDateTime == ((FirstFirstFirstPrototypeClass)obj).PrototypeDateTime;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), PrototypeDateTime);
    }
    
   
}