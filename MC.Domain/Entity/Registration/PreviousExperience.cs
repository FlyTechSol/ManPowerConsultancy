using MC.Domain.Base;

namespace MC.Domain.Entity.Registration
{
    public class PreviousExperience : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers
        public string? CompanyWorked { get; set; }
        public string? Place { get; set; }
        public string? Duration { get; set; }
        public string? ReasonForLeft { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? LeftDate { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; } = true; // Indicates if the reference is active
    }
}
