using MC.Application.ModelDto.Menu;
using MC.Application.ModelDto.Navigation;

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
        public string RegistrationId { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string Token { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public List<RoleDetails> Roles { get; set; } = new();
        //for two level Menu
        //public List<MenuDto> Menus { get; set; } = new();
        //for multi level menus
        public List<NavigationNodeDto> Menus { get; set; } = new();
    }
    public class RoleDetails
    {
        public string RoleName { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
    }
}
