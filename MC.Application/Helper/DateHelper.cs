using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Helper
{
    public static class DateHelper
    {
        public static bool IsWeekend(DateTime date) =>
            date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;

        public static DateTime GetFirstDayOfMonth(DateTime date) =>
            new DateTime(date.Year, date.Month, 1);

        public static DateTime GetLastDayOfMonth(DateTime date) =>
            new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    }
}
