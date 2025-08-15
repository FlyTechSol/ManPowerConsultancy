using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public string? InvalidField { get; }

        public ValidationException(string message, string? invalidField = null)
            : base(message)
        {
            InvalidField = invalidField;
        }
    }
}
