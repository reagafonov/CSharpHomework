using Prototype;

namespace TestPrototype;


public class TestIMyClonable
{
    public static object[] Classes = TestHelper.Classes;

    [TestCaseSource(nameof(Classes))]
    public void When_MyCloneable_Cloned_CloneIsNotSame<TClass>(TClass cloneable)
    where TClass:IMyClonable<TClass>
    {
        var clone = cloneable.MyClone();
        Assert.That(cloneable, Is.Not.SameAs(clone));
    }

    [TestCaseSource(nameof(Classes))]
    public void When_MyCloneable_Cloned_CloneIsEqual<TClass>(TClass cloneable)
        where TClass:IMyClonable<TClass>
    {
        var clone = cloneable.MyClone();
        Assert.That(cloneable, Is.EqualTo(clone));
    }
}