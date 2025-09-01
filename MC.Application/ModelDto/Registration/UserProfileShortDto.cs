
namespace MC.Application.ModelDto.Registration
{
    public class UserProfileShortDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string RegistrationId { get; set; } = null!;  
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? RoleName { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
