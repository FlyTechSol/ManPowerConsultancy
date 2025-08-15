using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Helper
{
    public static class AppHelper
    {
        public static Guid? NullIfEmpty(Guid? id)
        {
            return id == Guid.Empty ? null : id;
        }

        public static string? NullIfEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }

        public static bool IsGuidValid(Guid? id)
        {
            return id.HasValue && id != Guid.Empty;
        }

        public static bool IsDateValid(DateTime? date)
        {
            return date.HasValue && date.Value != default;
        }
    }
}
