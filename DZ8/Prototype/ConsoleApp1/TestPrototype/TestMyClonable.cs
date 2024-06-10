using Prototype;

namespace TestPrototype;

public class TestICloneable
{
    public static object[] Classes = TestHelper.Classes;

    [TestCaseSource(nameof(Classes))]
    public void When_Cloneable_Cloned_CloneIsNotSame<TClass>(TClass cloneable)
    where TClass:ICloneable
    {
        TClass clone = (TClass)cloneable.Clone();
        Assert.That(cloneable, Is.Not.SameAs(clone));
    }

    [TestCaseSource(nameof(Classes))]
    public void When_Cloneable_Cloned_CloneIsEqual<TClass>(TClass cloneable)
        where TClass:ICloneable
    {
        var clone = (TClass)cloneable.Clone();
        Assert.That(cloneable, Is.EqualTo(clone));
    }
}