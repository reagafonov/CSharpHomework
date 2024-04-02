namespace Prototype;

/// <summary>
/// Первый подкласс для демонстрации шаблона "Прототип"
/// </summary>
public class FirstSubClass:FirstBaseClass,IEquatable<FirstSubClass>
{
    public FirstSubClass()
    {
    }

    public FirstSubClass(FirstSubClass subclass)
        :base(subclass)
    {
        FloatProp = subclass.FloatProp;
    }

    /// <summary>
    /// Свойство с плавающей точкой
    /// </summary>
    public float FloatProp { get; set; }

    public bool Equals(FirstSubClass? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return base.Equals(other) && FloatProp.Equals(other.FloatProp);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FirstSubClass)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), FloatProp);
    }
}