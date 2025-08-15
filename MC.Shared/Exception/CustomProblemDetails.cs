using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Shared.Exception
{
    public class CustomProblemDetails
    {
        public string Title { get; set; } = "An error occurred";
        public int Status { get; set; }
        public string Type { get; set; } = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
        public string Detail { get; set; } = string.Empty;
        public string DisplayError { get; set; } = string.Empty;
        public IDictionary<string, string>? Errors { get; set; }
    }

}
