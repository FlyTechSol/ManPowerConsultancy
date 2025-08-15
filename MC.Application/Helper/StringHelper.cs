using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Helper
{
    public static class StringHelper
    {
        public static string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        public static bool IsNullOrTrimEmpty(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public static string SafeTrim(string input)
        {
            return input?.Trim() ?? string.Empty;
        }
    }
}
