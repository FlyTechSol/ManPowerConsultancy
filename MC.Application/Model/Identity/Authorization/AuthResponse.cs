using MC.Application.ModelDto.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Model.Identity.Authorization
{
    public class AuthResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? EmployeeNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public string Token { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        public List<RoleDetails> Roles { get; set; }  // Roles with RoleName and RoleId
        public List<MenuDto> Menus { get; set; } // Use MenuDto

    }
    public class RoleDetails
    {
        public string RoleName { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
    }
}
