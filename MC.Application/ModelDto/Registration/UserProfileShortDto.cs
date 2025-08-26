
namespace MC.Application.ModelDto.Registration
{
    public class UserProfileShortDto
    {
        public Guid Id { get; set; }
        public int RegistrationId { get; set; } 
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? RoleName { get; set; }
    }
}
