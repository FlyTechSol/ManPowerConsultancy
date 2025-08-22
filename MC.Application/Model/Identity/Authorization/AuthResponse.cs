using MC.Application.ModelDto.Menu;

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
        public string? RegistrationId { get; set; }
        public bool IsActive { get; set; } = true;
        public string Token { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public List<RoleDetails> Roles { get; set; } = new List<RoleDetails>();
        public List<MenuDto> Menus { get; set; } = new List<MenuDto>();
    }
    public class RoleDetails
    {
        public string RoleName { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
    }
}
