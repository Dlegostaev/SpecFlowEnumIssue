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

    public async Task<object> ConvertAsync(object value, IBindingType typeToConvertTo, CultureInfo cultureInfo)
    {
        return ConvertEnumWithDescription(value, typeToConvertTo) ??
               await stepArgumentTypeConverter.ConvertAsync(value, typeToConvertTo, cultureInfo);
    }

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