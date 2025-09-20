using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Settings
{
    public class EmailSettings
    {
        public string FromAddress { get; set; } = string.Empty;
        public string FromName { get; set; } = string.Empty;
        public string SmtpServer { get; set; } = string.Empty;// For SMTP
        public int SmtpPort { get; set; }  // SMTP Port
        public string SmtpUsername { get; set; } = string.Empty; // SMTP Username
        public string SmtpPassword { get; set; } = string.Empty; // SMTP Password
        public string ToAddress { get; set; } = string.Empty;
    }
}
