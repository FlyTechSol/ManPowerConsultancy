using MC.Domain.Base;

namespace MC.Domain.Entity.Registration
{
    public class Training : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers
        public string TrainingName { get; set; } = string.Empty;
        public string? TrainingInstitute { get; set; }
        public DateTime? TrainingStartDate { get; set; }
        public DateTime? TrainingEndDate { get; set; }
        public string? TrainingRemarks { get; set; }
        public string? TrainingCertificateUrl { get; set; }
        public bool IsActive { get; set; } = true; // Indicates if the reference is active
    }
}
