using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritedMapper
{
    public class DerivedClassesFactory
    {
        public static IEnumerable<T> CreateDerivedClasses<T>() where T : class
        {
            foreach (var derivedType in BaseClassHelper.GetAllDerivedClassesFromBaseClass(typeof(T)))
            {
                yield return (T) Activator.CreateInstance(derivedType);
            }
        }
    }
}
