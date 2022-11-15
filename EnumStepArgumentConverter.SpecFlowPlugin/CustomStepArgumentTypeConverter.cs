using System.ComponentModel;
using System.Globalization;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Bindings.Reflection;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Tracing;

namespace EnumStepArgumentConverter.SpecFlowPlugin;

public class CustomStepArgumentTypeConverter : IStepArgumentTypeConverter
{
    private readonly StepArgumentTypeConverter stepArgumentTypeConverter;

    public CustomStepArgumentTypeConverter(ITestTracer testTracer, IBindingRegistry bindingRegistry,
        IContextManager contextManager, IAsyncBindingInvoker bindingInvoker)
    {
        stepArgumentTypeConverter = new StepArgumentTypeConverter(testTracer, bindingRegistry, contextManager, bindingInvoker);
    }

    // Running ConvertEnumWithDescription method, it should not throw an exception here
    // (CanConvert will return false and ConvertAsync will not be executed in that case)
    // so we're just handling 2 states: 1st - Enum object returned, 2nd - null returned
    public async Task<object> ConvertAsync(object value, IBindingType typeToConvertTo, CultureInfo cultureInfo)
    {
        return ConvertEnumWithDescription(value, typeToConvertTo) ??
               await stepArgumentTypeConverter.ConvertAsync(value, typeToConvertTo, cultureInfo);
    }

    // Running ConvertEnumWithDescription method, it should throw an exception here while parsing steps
    // so we're handling 3 states: 1st - Enum object returned, 2nd - null returned, 3rd - exception thrown
    // 1st - means success, object and type are fine, so we're returning true
    // 2nd - object is not string or type is not an Enum with DescriptionAttributes, so we should treat it like regular Enum
    // and pass it to stepArgumentTypeConverter.CanConvert method
    // 3rd - object is string, Enum have DescriptionAttribute, but conversion is wrong, so returning false
    public bool CanConvert(object value, IBindingType typeToConvertTo, CultureInfo cultureInfo)
    {
        try
        {
            return ConvertEnumWithDescription(value, typeToConvertTo) is not null ||
                   stepArgumentTypeConverter.CanConvert(value, typeToConvertTo, cultureInfo);
        }
        catch (ArgumentException)
        {
            return false;
        }
    }

    /// <returns>Enum object if all conditions are met and Conversion is possible OR </returns>
    /// <returns>'null' if some of conditions are not met.</returns>
    /// <exception cref="T:ArgumentException">Throws when conditions are met but Conversion is not possible.</exception>
    private Enum? ConvertEnumWithDescription(object value, IBindingType typeToConvertTo)
    {
        if (typeToConvertTo is RuntimeBindingType runtimeBindingConvertToType && runtimeBindingConvertToType.Type.IsEnum &&
            IsTypeHaveDescriptionAttribute(runtimeBindingConvertToType.Type) &&
            value is string description)
        {
            return description.ConvertStringToEnum(runtimeBindingConvertToType.Type);
        }

        return null;
    }

    private bool IsTypeHaveDescriptionAttribute(Type convertToType)
    {
        foreach (var field in convertToType.GetFields())
        {
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute)
                return true;
        }

        return false;
    }
}