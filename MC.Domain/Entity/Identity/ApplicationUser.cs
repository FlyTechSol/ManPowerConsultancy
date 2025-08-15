using MC.Domain.Entity.Master;
using Microsoft.AspNetCore.Identity;

namespace MC.Domain.Entity.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid? TitleId { get; set; }
        public Title? Title { get; set; } // Navigation property
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? EmployeeNumber { get; set; }
        public bool IsActive { get; set; } = true; // Default to true, can be set to false for deactivation
    }
}
