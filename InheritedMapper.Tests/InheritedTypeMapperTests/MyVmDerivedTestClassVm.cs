using InheritedMapper.Interfaces;

namespace InheritedMapper.Tests.InheritedTypeMapperTests;

public class MyVmDerivedTestClassVm : Vm, IVmWithPropertyType
{
    public string MyVmDerivedTestClassVmType { get; set; }
    public void SetTargetVmType(string vmTypeName)
    {
        MyVmDerivedTestClassVmType = vmTypeName;
    }
}