namespace Prototype;

public class FourthSubClass:FirstBaseClass,IEquatable<FourthSubClass>
{
    public FourthSubClass()
    {}

    public FourthSubClass(FourthSubClass fourthSubClass)
        : base(fourthSubClass)
    {
        SomeProp = fourthSubClass.SomeProp;
    }
    public string SomeProp { get; set; }

    public bool Equals(FourthSubClass? other)
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
        return Equals((FourthSubClass)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), SomeProp);
    }
}