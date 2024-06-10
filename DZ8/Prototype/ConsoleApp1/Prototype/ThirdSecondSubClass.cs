namespace Prototype;

/// <summary>
/// Третий вложенный 1 раз класс
/// </summary>
public class ThirdSecondSubClass:SecondBaseClass,ICloneable, IMyClonable<ThirdSecondSubClass>
{
    public ThirdSecondSubClass()
    {}

    public ThirdSecondSubClass(ThirdSecondSubClass third)
        : base(third)
    {
        DoubleProp = third.DoubleProp;
    }
    public double DoubleProp { get; set; }
    
    public override ThirdSecondSubClass MyClone()
    {
        return new ThirdSecondSubClass(this);
    }

    object ICloneable.Clone()
    {
        return MyClone();
    }
}