using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.ModelDto.Base
{
    public abstract class AuditableDto
    {
        public string DateCreated { get; set; } = string.Empty;
        public string DateModified { get; set; } = string.Empty;
        public string CreatedByName { get; set; } = string.Empty;
        public string ModifiedByName { get; set; } = string.Empty;
    }
}
