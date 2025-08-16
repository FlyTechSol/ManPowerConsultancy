using MC.Application.ModelDto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.ModelDto.Master.Master
{
    public class GenderDetailDto : AuditableDto
    {
        public int DisplayOrder { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Decode { get; set; } = string.Empty;
    }
}
