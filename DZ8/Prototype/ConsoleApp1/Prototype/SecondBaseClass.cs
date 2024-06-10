namespace Prototype;

/// <summary>
/// Второй базовый класс
/// </summary>
public class SecondBaseClass:IEquatable<SecondBaseClass>,ICloneable,IMyClonable<SecondBaseClass>
{
    public SecondBaseClass()
    {
        
    }

    public SecondBaseClass(SecondBaseClass secondBase)
    {
        IntProp = secondBase.IntProp;
    }
    /// <summary>
    /// Целочисленное свойство
    /// </summary>
    public int  IntProp { get; set; }

    public bool Equals(SecondBaseClass? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return IntProp == other.IntProp;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SecondBaseClass)obj);
    }

    public override int GetHashCode()
    {
        return IntProp;
    }
    
    public virtual SecondBaseClass MyClone()
    {
        return new SecondBaseClass(this);
    }

    object ICloneable.Clone()
    {
        return MyClone();
    }
}