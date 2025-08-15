using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public string ResourceName { get; }
        public object ResourceKey { get; }

        public NotFoundException(string resourceName, object key)
            : base($"{resourceName} with key {key} was not found.")
        {
            ResourceName = resourceName;
            ResourceKey = key;
        }
    }
}
