using Prototype;

namespace TestPrototype;

public class TestHelper
{
    public static object[] Classes =
        new object[]
        {
           
                new FirstFirstFirstPrototypeClass()
                {
                    Data = "test1",
                    DataDateTime = DateTime.Now,
                    FloatProp = Random.Shared.NextSingle(),
                    PrototypeDateTime = DateTime.UtcNow
                },
               
            
                new SecondSecondSecondPrototypeClass()
                {
                    IntProp = Random.Shared.Next()
                },
          
           
          
                new ThirdThirdSecondPrototypeClass()
                {
                    DoubleProp = Random.Shared.NextDouble(),
                    IntProp = Random.Shared.Next()
                },
          
                new FourthFourthFirstPrototypeClass()
                {
                    Data = "fdgfdgdfg",
                    DataDateTime = DateTime.FromOADate(Random.Shared.NextDouble()),
                    Dictionary = new Dictionary<string, string>()
                    {
                        { "dfdsfdf", "sdfdsfdsfdfsdfdf" },
                        { "34343434", "343432432432434" }
                    }
                }
           
        };

}