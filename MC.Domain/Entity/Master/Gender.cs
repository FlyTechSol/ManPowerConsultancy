using MC.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Domain.Entity.Master
{
    public class Gender : BaseEntity
    {
        public int DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Decode { get; set; } = string.Empty;
    }
}
