namespace Prototype;

/// <summary>
/// Третий класс
/// </summary>
public class ThirdPrototypeClass:ThirdSubClass, IMyClonable<ThirdPrototypeClass>,
    ICloneable
{
    public ThirdPrototypeClass()
    {}

    public ThirdPrototypeClass(ThirdPrototypeClass prototype)
        :base(prototype)
    {
        
    }
    
    public ThirdPrototypeClass Clone()
    {
        return new ThirdPrototypeClass(this);
    }

    object ICloneable.Clone()
    {
        return Clone();
    }
}