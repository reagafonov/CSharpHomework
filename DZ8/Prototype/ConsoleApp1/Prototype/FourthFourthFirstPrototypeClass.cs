namespace Prototype;

/// <summary>
/// Четвертый класс
/// Дважды вложенный
/// </summary>
public class FourthFourthFirstPrototypeClass:FourthFirstSubClass, IMyClonable<FourthFourthFirstPrototypeClass>,
    ICloneable,IEquatable<FourthFourthFirstPrototypeClass>
{
    public FourthFourthFirstPrototypeClass()
    {}

    public FourthFourthFirstPrototypeClass(FourthFourthFirstPrototypeClass prototype)
        :base(prototype)
    {
        Dictionary = prototype.Dictionary
            .ToDictionary(x => x.Key, x => x.Value);
    }
    public Dictionary<string,string> Dictionary { get; set; }
    public override FourthFourthFirstPrototypeClass MyClone()
    {
        return new FourthFourthFirstPrototypeClass(this);
    }

    object ICloneable.Clone()
    {
        return MyClone();
    }

    public bool Equals(FourthFourthFirstPrototypeClass? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return base.Equals(other) && Dictionary.SequenceEqual(other.Dictionary);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FourthFourthFirstPrototypeClass)obj);
    }

    public override int GetHashCode()
    {
        var code = new HashCode();
        code.Add(base.GetHashCode());
        foreach (var pair in Dictionary)
        {
            code.Add(pair);
        }
        
        return HashCode.Combine(base.GetHashCode(), Dictionary.GetHashCode());
    }
}