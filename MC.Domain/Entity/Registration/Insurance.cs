using MC.Domain.Base;

namespace MC.Domain.Entity.Registration
{
    public class Insurance : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers
        public string InsuranceCompanyName { get; set; } = string.Empty;
        public string PolicyNumber { get; set; } = string.Empty;
        public DateTime? PolicyStartDate { get; set; }
        public DateTime? PolicyEndDate { get; set; }
        public string? PolicyRemarks { get; set; }
        public bool IsActive { get; set; } = true; // Indicates if the reference is active
    }
}
