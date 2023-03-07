using System;
using System.Collections.Generic;
using System.Reflection;
using Nelibur.ObjectMapper;

namespace InheritedMapper
{
    public class VmToDerivedVm
    {
        public static object GetDerivedObject<T>(T baseVmObject)
        {
            PropertyInfo[] properties = baseVmObject.GetType().GetProperties();

            var className = baseVmObject.GetType().Name;
            if (className.EndsWith("Vm") || className.EndsWith("Im") || className.EndsWith("Um") || className.EndsWith("Dm"))
            {
                className = className.Substring(0, className.Length - 2);
            }

            foreach (var property in properties)
            {
                var name = className + "Type";
                if (property.Name == name)
                {
                    var targetClassName = property.GetValue(baseVmObject)?.ToString();
                    var derivedType = BaseClassHelper.GetDerivedType(typeof(T), targetClassName);
                    var resultObject = TinyMapper.Map(baseVmObject.GetType(), derivedType, baseVmObject);

                    return resultObject;
                }
            }

            return baseVmObject;
        }

        public static object GetDerivedObjects<T>(dynamic baseVmObject) where T : new()
        {
            List<T> newList = new List<T>();

            foreach (var baseObj in baseVmObject)
            {
                Console.WriteLine(baseObj);
                var derivedObject = GetDerivedObject(baseObj);
                newList.Add(derivedObject);
            }

            return newList;
        }
    }
}