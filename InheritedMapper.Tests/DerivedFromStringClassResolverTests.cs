using InheritedMapper.Tests.SampleClasses;
using NUnit.Framework;

namespace InheritedMapper.Tests;

public class DerivedFromStringClassResolverTests
{
    [Test]
    public void GetInstance_ShouldReturnInstanceOfDerivedClass()
    {
        var s = new DerivedFromStringClassResolver<ExpandedBaseAbstract>().GetInstance(nameof(ExpandedBase));
        Assert.That(s, Is.InstanceOf<ExpandedBase>());
    }
}