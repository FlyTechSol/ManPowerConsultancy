using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Settings
{
    public class AppSettings
    {
        public string TimeZone { get; set; } = string.Empty;
        public DateTimeFormats DateTimeFormats { get; set; } = new DateTimeFormats();
    }
    public class DateTimeFormats
    {
        public string Default { get; set; } = "dd-MM-yyyy HH:mm:ss";
        public string Option1 { get; set; } = "MM/dd/yyyy hh:mm tt";
        public string Option2 { get; set; } = "yyyy-MM-dd HH:mm";
        public string Option3 { get; set; } = "dddd, dd MMMM yyyy HH:mm:ss";
    }
}
