using System.Collections;

namespace Prototype;

/// <summary>
/// Второй класс
/// </summary>
public class SecondPrototypeClass:SecondSubClass, IMyClonable<SecondPrototypeClass>,
    ICloneable,IEquatable<SecondPrototypeClass>
{
    public SecondPrototypeClass()
    {}

    public SecondPrototypeClass(SecondPrototypeClass prototype)
        :base(prototype)
    {
        
    }

    public SecondPrototypeClass Clone()
    {
        return new SecondPrototypeClass(this);
    }

    object ICloneable.Clone()
    {
        return Clone();
    }

    public bool Equals(SecondPrototypeClass? other)
    {
        return this.Equals((SecondSubClass)other);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SecondPrototypeClass)obj);
    }

    public override int GetHashCode()
    {
        Hashtable table = new();
        var baseCode = base.GetHashCode();
        table.Add(baseCode);
    }
}