using MC.Domain.Base;
using MC.Domain.Entity.Enum.Registration;

namespace MC.Domain.Entity.Registration
{
    public class Family : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers
        public string Name { get; set; } = string.Empty;
        public Relationship Relationship { get; set; }
        public bool IsPFNominee { get; set; } = false;
        public double? PFPercentage { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; } = string.Empty;
        public string? RelationTo { get; set; }
        public bool IsMinor { get; set; } = false;
        public bool IsDependent { get; set; } = false;
        public bool IsResidingWithEmployee { get; set; } = false;
        public bool IsActive { get; set; } = true; // Indicates if the reference is active
    }
}
