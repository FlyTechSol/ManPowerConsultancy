using MC.Domain.Entity.Registration;
using Microsoft.AspNetCore.Identity;

namespace MC.Domain.Entity.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public bool IsActive { get; set; } = true; // Default to true, can be set to false for deactivation
        public UserProfile? UserProfile { get; set; }
    }
}
