namespace Prototype;

/// <summary>
/// Второй 1 раз вложенный класс
/// </summary>
public class SecondSecondSubClass:SecondBaseClass,ICloneable,IMyClonable<SecondSecondSubClass>
{
    public SecondSecondSubClass()
    {
        
    }

    public SecondSecondSubClass(SecondSecondSubClass subClass)
        : base(subClass)
    {
        
    }
    void SomeMethod() { }
    
    public override SecondSecondSubClass MyClone()
    {
        return new SecondSecondSubClass(this);
    }

    object ICloneable.Clone()
    {
        return MyClone();
    }
    
}