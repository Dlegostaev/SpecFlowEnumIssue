using System.ComponentModel;

namespace SpecFlowEnumIssue.Utils;

// Enum transform with usage of description
public static class EnumEx
{
    public static T AsEnum<T>(this string description) where T : System.Enum
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