using System.ComponentModel;
using System.Reflection;

namespace ClinicHistoryPro.Application.MethodExtend
{
    public static class EnumExtencions
    {
        public static string Description(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
