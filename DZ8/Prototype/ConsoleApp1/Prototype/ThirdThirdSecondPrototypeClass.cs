namespace Prototype;

/// <summary>
/// Третий класс
/// Третий дважды вложенный класс
/// </summary>
public class ThirdThirdSecondPrototypeClass:ThirdSecondSubClass, IMyClonable<ThirdThirdSecondPrototypeClass>,
    ICloneable
{
    public ThirdThirdSecondPrototypeClass()
    {}

    public ThirdThirdSecondPrototypeClass(ThirdThirdSecondPrototypeClass prototype)
        :base(prototype)
    {
        
    }
    
    public override ThirdThirdSecondPrototypeClass MyClone()
    {
        return new ThirdThirdSecondPrototypeClass(this);
    }

    object ICloneable.Clone()
    {
        return MyClone();
    }
}