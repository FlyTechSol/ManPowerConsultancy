using MC.Domain.Base;
using MC.Domain.Entity.Enum.Registration;

namespace MC.Domain.Entity.Registration
{
    public class PoliceVerification : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers
        public string PoliceStationName { get; set; } = string.Empty;
        public PoliceVerificationStatus VerificationStatus { get; set; } 
        public DateTime? VerificationDate { get; set; }
        public string? VerificationRemarks { get; set; }
        public bool IsActive { get; set; } = true; // Indicates if the reference is active
    }
}
