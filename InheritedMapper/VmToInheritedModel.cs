using Nelibur.ObjectMapper;

namespace InheritedMapper;

public class VmToInheritedModel
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="viewModel">Implement IViewModelInheritance in Your view model</param>
    /// <param name="abstractBaseType">Specify base class of target model</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static TDestination TryCreate<TSource, TDestination>(
        TSource viewModel, string inheritedClassName, Type abstractBaseType)
        where TSource : class
    {
        var derivedTypes = BaseClassHelper.GetAllDerivedClassesFromBaseClass(abstractBaseType);
        if (derivedTypes.Any())
        {
            var target = derivedTypes.FirstOrDefault(x => x.Name == inheritedClassName);
            if (target == null)
                throw new DidNotFoundInheritedBaseClassException($"Could not found derive class name - {inheritedClassName}");

            TinyMapper.Bind(typeof(TSource), target);

            var instance = (TDestination)Activator.CreateInstance(target);
            TinyMapper.Map(typeof(TSource), target, viewModel, instance);

            if (instance == null) throw new CouldNotCreateDerivedClassTypeException("Could not create  derived class type.");
            return instance;
        }
        else
        {
            throw new DidNotFoundBaseAbstractClassException($"Could not find base, abstract class : {abstractBaseType.Name} in Assembly where located is class : {abstractBaseType.Name}");
        }
    }

    public class DidNotFoundInheritedBaseClassException : Exception
    {
        public DidNotFoundInheritedBaseClassException(string message) : base(message)
        {
        }
    }
    public class DidNotFoundBaseAbstractClassException : Exception
    {
        public DidNotFoundBaseAbstractClassException(string message) : base(message)
        {
        }
    }

    public class CouldNotCreateDerivedClassTypeException : Exception
    {
        public CouldNotCreateDerivedClassTypeException(string message) : base(message)
        {

        }
    }
}

