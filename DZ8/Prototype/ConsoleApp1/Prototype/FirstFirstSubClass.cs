using System.Reflection.Metadata.Ecma335;

namespace Prototype;

/// <summary>
/// Первый подкласс для демонстрации шаблона "Прототип"
/// Дважды вложенный класс
/// </summary>
public class FirstFirstSubClass:FirstBaseClass,IEquatable<FirstFirstSubClass>,
    ICloneable,IMyClonable<FirstFirstSubClass>
{
    public FirstFirstSubClass()
    {
    }

    public FirstFirstSubClass(FirstFirstSubClass subclass)
        :base(subclass)
    {
        FloatProp = subclass.FloatProp;
    }

    /// <summary>
    /// Свойство с плавающей точкой
    /// </summary>
    public float FloatProp { get; set; }

    public bool Equals(FirstFirstSubClass? other)
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
        if (!FloatProp.Equals(((FirstFirstSubClass)obj).FloatProp)) return false;
        return base.Equals(obj); 
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), FloatProp);
    }
    
    public override FirstFirstSubClass MyClone()
    {
        return new FirstFirstSubClass(this);
    }

    object ICloneable.Clone()
    {
        return new FirstFirstSubClass(this);
    }
}