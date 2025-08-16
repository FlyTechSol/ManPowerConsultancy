using MC.Application.ModelDto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.ModelDto.Common.Email
{
    public class EmailTemplateDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public string TemplateName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
