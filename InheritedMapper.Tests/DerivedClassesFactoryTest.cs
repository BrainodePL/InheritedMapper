using InheritedMapper.Tests.SampleClasses;
using NUnit.Framework;

namespace InheritedMapper.Tests;

public class DerivedClassesFactoryTest
{
    [Test]
    public void DerivedClassesFactoryCreate_shouldCreateAllDerivedClassesFromSpecifiedBaseClass()
    {
        var allDerivedClassesCount = BaseClassHelper.GetAllDerivedClassesFromBaseClass(typeof(SampleBase));
        
        var derivedClasses = DerivedClassesFactory.CreateDerivedClasses<SampleBase>();
        
        Assert.True(derivedClasses.Count() == allDerivedClassesCount.Length);
    }
}