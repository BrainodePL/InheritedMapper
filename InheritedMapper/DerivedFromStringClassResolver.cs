using System;
using System.Linq;

namespace InheritedMapper
{
    public class DerivedFromStringClassResolver<T> where T : class
    {
        public object GetInstance(string className)
        {
            var targetType = DerivedClassesFactory.CreateDerivedClasses<T>().First(x => String.Equals(x.GetType().Name, className, StringComparison.OrdinalIgnoreCase)).GetType();
            return Activator.CreateInstance(targetType);
        }
    }
}