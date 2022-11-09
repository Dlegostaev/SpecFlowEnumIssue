using System.ComponentModel;

namespace EnumStepArgumentConverter.SpecFlowPlugin;

public static class EnumProcessing
{
    // If you would like to copy this method to your project please review it attentively
    // as it have been made by me just for quick reference that AsEnum<T> method is working correctly with plugin
    public static Enum ConvertStringToEnum(this string value, Type type)
    {
        var arguments = new object[] {value};
        const string methodName = nameof(AsEnum);
        var classType = typeof(EnumProcessing);

        try
        {
            return (Enum) classType.GetMethod(methodName)
                .MakeGenericMethod(type).Invoke(null, arguments);
        }
        catch (System.Reflection.TargetInvocationException e)
        {
            throw e.GetBaseException();
        }
        catch (NullReferenceException e)
        {
            throw new InvalidOperationException("Please check the class type and method name inside this method", e);
        }
    }

    // If you would like to copy this method to your project please review it attentively also,
    // as it was copied from stackoverflow answer and wasn't reviewed by me
    public static T AsEnum<T>(this string description) where T : Enum
    {
        foreach(var field in typeof(T).GetFields())
        {
            if (Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                if (attribute.Description == description)
                    return (T)field.GetValue(null);
            }
            else
            {
                if (field.Name == description)
                    return (T)field.GetValue(null);
            }
        }

        throw new ArgumentException("Not found.", nameof(description));
        // Or return default(T);
    }
}