namespace Prototype;

/// <summary>
/// Базовый класс для демонстрации шаблона "Прототип"
/// </summary>
public class FirstBaseClass:IEquatable<FirstBaseClass>,ICloneable,IMyClonable<FirstBaseClass>
{
    public FirstBaseClass()
    {
    }

    public FirstBaseClass(FirstBaseClass cloning)
    {
        Data = cloning.Data;
        DataDateTime = cloning.DataDateTime;
    }

    /// <summary>
    /// Поле типа string
    /// </summary>
    public string Data { get; set; }
    
    /// <summary>
    /// Поле типа DateTime
    /// </summary>
    public DateTime DataDateTime { get; set; }

    /// <summary>
    /// Метод
    /// </summary>
    /// <returns></returns>
    public string GetData() => DataDateTime.ToString("h:mm:ss tt zz");

    public bool Equals(FirstBaseClass? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Data == other.Data && DataDateTime.Equals(other.DataDateTime);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FirstBaseClass)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Data, DataDateTime);
    }
    
    public virtual FirstBaseClass MyClone()
    {
        return new FirstBaseClass(this);
    }

    object ICloneable.Clone()
    {
        return MyClone();
    }
}