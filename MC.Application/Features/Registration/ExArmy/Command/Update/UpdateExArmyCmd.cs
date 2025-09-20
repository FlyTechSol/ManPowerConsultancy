using MC.Domain.Entity.Enum.Registration;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MC.Application.Features.Registration.ExArmy.Command.Update
{
    public class UpdateExArmyCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string? ServiceNumber { get; set; } // Service number in the army
        public string? Rank { get; set; } // Rank in the army
        public string? Unit { get; set; } // Unit in the army
        public ArmyBranch? BranchOfService { get; set; } // Branch of service (e.g., Army, Navy, Air Force)
        public string? TotalService { get; set; } // Total service held in the army
        public DateTime? EnlistmentDate { get; set; } // Date of enlistment
        public DateTime? DischargeDate { get; set; } // Date of discharge
        public string? ReasonForDischarge { get; set; } // Reason for discharge from the army
        public IFormFile? DischargeCertificateUrl { get; set; }
    }
}
