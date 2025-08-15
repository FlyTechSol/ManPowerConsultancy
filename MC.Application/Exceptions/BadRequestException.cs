using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public IDictionary<string, string[]>? ValidationErrors { get; }

        public BadRequestException(string message, IDictionary<string, string[]>? errors = null)
            : base(message)
        {
            ValidationErrors = errors;
        }
    }
}
