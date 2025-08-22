using MC.Domain.Base;
using MC.Domain.Entity.Enum.Registration;

namespace MC.Domain.Entity.Registration
{
    public class ExArmy : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers
        public string? ServiceNumber { get; set; } // Service number in the army
        public string? Rank { get; set; } // Rank in the army
        public string? Unit { get; set; } // Unit in the army
        public ArmyBranch? BranchOfService { get; set; } // Branch of service (e.g., Army, Navy, Air Force)
        public string? TotalService { get; set; } // Total service held in the army
        public DateTime? EnlistmentDate { get; set; } // Date of enlistment
        public DateTime? DischargeDate { get; set; } // Date of discharge
        public string? ReasonForDischarge { get; set; } // Reason for discharge from the army
        public string? DischargeCertificateUrl { get; set; } // URL to the discharge certificate document
        public bool IsActive { get; set; } = true; // Indicates if the reference is active
    }
}
