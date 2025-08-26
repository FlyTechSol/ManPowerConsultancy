using MC.Domain.Base;

namespace MC.Domain.Entity.Registration
{
    public class Communication : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers
        public string PersonalMobileNumber { get; set; } = string.Empty;
        public string? OfficialMobileNumber { get; set; }
        public string EmergencyContactNumber { get; set; } = string.Empty;
        public string? LandlineNumber1 { get; set; } 
        public string? LandlineNumber2 { get; set; }
        public string? PersonalEmail { get; set; } 
        public string? OfficialEmail { get; set; } 
        public bool IsActive { get; set; } = true;
    }
}
