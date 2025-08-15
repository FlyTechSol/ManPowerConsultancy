using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.ModelDto.Common.Email
{
    public class EmailTemplateDetailDto
    {
        public Guid Id { get; set; }
        public string TemplateName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string DateCreated { get; set; } = string.Empty;
        public string DateModified { get; set; } = string.Empty;
        public string CreatedByName { get; set; } = string.Empty;
        public string ModifiedByName { get; set; } = string.Empty;
    }
}
