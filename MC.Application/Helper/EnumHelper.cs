using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Helper
{
    public static class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field?.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description ?? value.ToString();
        }

        public static TEnum ParseOrDefault<TEnum>(string input, TEnum defaultValue) where TEnum : struct
        {
            return Enum.TryParse(input, true, out TEnum result) ? result : defaultValue;
        }
    }
}
