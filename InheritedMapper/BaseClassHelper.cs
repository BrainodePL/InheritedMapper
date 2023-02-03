using System.Reflection;

namespace InheritedMapper
{
    public class BaseClassHelper
    {
        public static Type[] GetAllDerivedClassesFromBaseClass(Type baseClassType)
        {
            Assembly asm = baseClassType.GetTypeInfo().Assembly;

            var types = asm.DefinedTypes.Where(x => x.BaseType == (baseClassType));
            var result = types.Select(x => x.AsType());
            return result.ToArray();
        }

        public static Type[] GetAllDerivedGenericClassesFromBaseClass(Type baseClassType)
        {
            Assembly asm = baseClassType.GetTypeInfo().Assembly;
            var types = asm.DefinedTypes.Where(x => x.IsClass && x.BaseType.Name == (baseClassType.Name));
            var result = types.Select(x => x.AsType());

            return result.ToArray();
        }

        public static Type GetDerivedType(Type baseClassType, string derivedClassName)
        {
            Type[] targetClass = GetAllDerivedClassesFromBaseClass(baseClassType);
            var realizationClassType = targetClass.First(type => type.Name == derivedClassName);
            return realizationClassType;
        }
    }
}