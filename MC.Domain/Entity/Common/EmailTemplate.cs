using MC.Domain.Base;
using MC.Domain.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Domain.Entity.Common
{
    public class EmailTemplate : BaseEntity
    {
        public EmailTemplateType TemplateName { get; set; }  // A name to identify the template (e.g., "SignIn", "PasswordReset", etc.)
        public string Subject { get; set; } = string.Empty; // The subject of the email
        public string Body { get; set; } = string.Empty; // The body of the email (HTML content)
    }
}
