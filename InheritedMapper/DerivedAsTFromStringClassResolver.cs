using System;
using System.Linq;

namespace InheritedMapper
{
    public class DerivedAsTFromStringClassResolver<T> where T : class
    {
        public T GetInstance(string className)
        {
            var targetType = DerivedClassesFactory.CreateDerivedClasses<T>().First(x => String.Equals(x.GetType().Name, className, StringComparison.OrdinalIgnoreCase)).GetType();
            return (T) Activator.CreateInstance(targetType);
        }
    }
}