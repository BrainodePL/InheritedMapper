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

            var name = className + "Type";
            foreach (var property in properties)
            {
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
                var derivedObject = GetDerivedObject(baseObj);
                newList.Add(derivedObject);
            }

            return newList;
        }
    }
}