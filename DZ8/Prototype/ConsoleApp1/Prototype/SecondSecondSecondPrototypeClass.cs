using System.Collections;

namespace Prototype;

/// <summary>
/// Второй класс
/// Дважды вложенный
/// </summary>
public class SecondSecondSecondPrototypeClass:SecondSecondSubClass, IMyClonable<SecondSecondSecondPrototypeClass>,
    ICloneable,IEquatable<SecondSecondSecondPrototypeClass>
{
    public SecondSecondSecondPrototypeClass()
    {}

    public SecondSecondSecondPrototypeClass(SecondSecondSecondPrototypeClass prototype)
        :base(prototype)
    {
        
    }

    public override SecondSecondSecondPrototypeClass MyClone()
    {
        return new SecondSecondSecondPrototypeClass(this);
    }

    object ICloneable.Clone()
    {
        return MyClone();
    }

    public bool Equals(SecondSecondSecondPrototypeClass? other)
    {
        return this.Equals((SecondSecondSubClass)other);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SecondSecondSecondPrototypeClass)obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}