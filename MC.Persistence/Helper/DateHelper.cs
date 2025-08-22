using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Persistence.Helper
{
    public static class DateHelper
    {
        private static TimeZoneInfo? _timeZone;
        private static string? _dateFormat;

        public static void Configure(string timeZoneId, string dateFormat)
        {
            _timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            _dateFormat = dateFormat;
        }

        public static string FormatDate(DateTime? utcDate) =>
            utcDate.HasValue && _timeZone != null && _dateFormat != null
                ? TimeZoneInfo.ConvertTimeFromUtc(utcDate.Value, _timeZone).ToString(_dateFormat)
                : string.Empty;
    }
}
