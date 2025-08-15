using MC.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Domain.Entity.Exception
{
    public class ExceptionLog : BaseEntity
    {
        public string Method { get; set; } = default!;
        public string Page { get; set; } = default!;
        public string Component { get; set; } = "API";
        public string ExceptionMessage { get; set; } = default!;
        public string StackTrace { get; set; } = default!;
        public string InnerException { get; set; } = default!;
        public string QueryString { get; set; } = default!;
        public string UserAgent { get; set; } = default!;
        public string IpAddress { get; set; } = default!;
        public DateTime Timestamp { get; set; }
    }

}
