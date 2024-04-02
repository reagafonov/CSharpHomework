namespace Prototype;

public class SecondSubClass:SecondBaseClass
{
    public SecondSubClass()
    {
        
    }

    public SecondSubClass(SecondSubClass subClass)
        : base(subClass)
    {
        
    }
    void SomeMethod() { }
}