namespace Prototype;

/// <summary>
/// Вложенный 1 раз класс от первого класса
/// </summary>
public class FourthFirstSubClass:FirstBaseClass,IEquatable<FourthFirstSubClass>,ICloneable,IMyClonable<FourthFirstSubClass>
{
    public FourthFirstSubClass()
    {}

    public FourthFirstSubClass(FourthFirstSubClass fourthSubClass)
        : base(fourthSubClass)
    {
        SomeProp = fourthSubClass.SomeProp;
    }
    public string SomeProp { get; set; }

    public bool Equals(FourthFirstSubClass? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return base.Equals(other) && SomeProp == other.SomeProp;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FourthFirstSubClass)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), SomeProp);
    }
    
    public override FourthFirstSubClass MyClone()
    {
        return new FourthFirstSubClass(this);
    }

    object ICloneable.Clone()
    {
        return MyClone();
    }
}