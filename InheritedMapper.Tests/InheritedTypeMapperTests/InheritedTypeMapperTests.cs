using System.Diagnostics;
using Nelibur.ObjectMapper;
using NUnit.Framework;

namespace InheritedMapper.Tests.InheritedTypeMapperTests
{
    public class InheritedTypeMapperTests
    {
        [Test]
        public void InheritedTypeMapper_MapAndModify_shouldMapOneListToAnotherWithSettingDeriveClassTypeProperty()
        {
            var vms = new List<Vm>()
            {
                new AVm(), new BVm(), new BVm()
            };
            var stopwatch = new Stopwatch();
            TinyMapper.Bind<Vm, MyVmDerivedTestClassVm>();
            TinyMapper.Bind<AVm, MyVmDerivedTestClassVm>();
            TinyMapper.Bind<BVm, MyVmDerivedTestClassVm>();
            TinyMapper.Bind<List<Vm>, List<MyVmDerivedTestClassVm>>();

           
            stopwatch.Start();

            List<MyVmDerivedTestClassVm> myVmDerivedTestClassVms  = InheritedTypeMapper.MapAndModify<Vm, MyVmDerivedTestClassVm>(vms);
            stopwatch.Stop();
            
            Assert.That(myVmDerivedTestClassVms.First().MyVmDerivedTestClassVmType == "AVm");
            Assert.That(myVmDerivedTestClassVms.Last().MyVmDerivedTestClassVmType == "BVm");
            Console.WriteLine($"Method take : {stopwatch.ElapsedTicks} ticks");
        }

        [Test]
        public void InheritedTypeMapper_MapAndModifyUsingReflection_shouldMapOneListToAnotherWithSettingDeriveClassTypeProperty()
        {
            var vms = new List<Vm>()
            {
                new AVm(), new BVm(), new BVm()
            };
            var stopwatch = new Stopwatch();
            TinyMapper.Bind<Vm, MyVmDerivedTestClassVm>();
            TinyMapper.Bind<AVm, MyVmDerivedTestClassVm>();
            TinyMapper.Bind<BVm, MyVmDerivedTestClassVm>();
            TinyMapper.Bind<List<Vm>, List<MyVmDerivedTestClassVm>>();

            stopwatch.Start();
            var myVmDerivedTestClassVms = InheritedTypeMapper.MapAndModifyUsingReflection<Vm, MyVmDerivedTestClassVm>(vms);
            stopwatch.Stop();

            Assert.That(myVmDerivedTestClassVms.First().MyVmDerivedTestClassVmType == "AVm");
            Assert.That(myVmDerivedTestClassVms.Last().MyVmDerivedTestClassVmType == "BVm");
            Console.WriteLine($"Method take : {stopwatch.ElapsedTicks} ticks");
        }

    }
}