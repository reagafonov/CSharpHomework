namespace Prototype;

public class ThirdSubClass:SecondBaseClass
{
    public ThirdSubClass()
    {}

    public ThirdSubClass(ThirdSubClass third)
        : base(third)
    {
        DoubleProp = third.DoubleProp;
    }
    public double DoubleProp { get; set; }
}