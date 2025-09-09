using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Model.Identity.Registration
{
    public class RegistrationRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RoleId { get; set; } = string.Empty;
    }
}
