using System.Collections.Generic;
using System.Text.Json;

namespace InheritedMapper
{
    public class DerivedVmClassResolver<T> where T : class, new()
    {
        public object Get(string serializedDerivedFromBaseClass)
        {
            
            var deserialized = JsonSerializer.Deserialize<T>(serializedDerivedFromBaseClass, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            var derivedVm = VmToDerivedVm.GetDerivedObject(deserialized);
            return derivedVm;
        }

        public object GetMany(string serializedDerivedFromBaseClass)
        {
            
            var deserialized = JsonSerializer.Deserialize<List<T>>(serializedDerivedFromBaseClass, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            var derivedVm = VmToDerivedVm.GetDerivedObjects<T>(deserialized);
            return derivedVm;
        }
    }
}