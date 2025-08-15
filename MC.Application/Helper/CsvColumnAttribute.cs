using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Helper
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CsvColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public int Order { get; set; }

        public CsvColumnAttribute(string name, int order)
        {
            Name = name;
            Order = order;
        }
    }
}
