using Prototype;

namespace TestPrototype;

public class TestMyClonable
{
    private FirstPrototypeClass _firstPrototypeClass;
    private SecondPrototypeClass _secondPrototypeClass;
    private ThirdPrototypeClass _thirdPrototypeClass;
    private FourthPrototypeClass _fourthPrototypeClass;

    [SetUp]
    public void SetUp()
    {
        _firstPrototypeClass = new FirstPrototypeClass()
        {
            Data = "test1",
            DataDateTime = DateTime.Now,
            FloatProp = Random.Shared.NextSingle(),
            PrototypeDateTime = DateTime.UtcNow
        };

        _secondPrototypeClass = new SecondPrototypeClass()
        {
            IntProp = Random.Shared.Next()
        };

        _thirdPrototypeClass = new ThirdPrototypeClass()
        {
            DoubleProp = Random.Shared.NextDouble(),
            IntProp = Random.Shared.Next()
        };

        _fourthPrototypeClass = new FourthPrototypeClass()
        {
            Data = "fdgfdgdfg",
            DataDateTime = DateTime.FromOADate(Random.Shared.NextDouble()),
            Dictionary = new Dictionary<string, string>()
            {
                {"dfdsfdf","sdfdsfdsfdfsdfdf"},
                {"34343434","343432432432434"}
            }
        };
        
    }
    
    

    [Test]
    public void TestFirstClone()
    {
        _firstPrototypeClass
    }
}