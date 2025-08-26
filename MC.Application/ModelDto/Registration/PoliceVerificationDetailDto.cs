using MC.Application.ModelDto.Base;
using MC.Domain.Entity.Enum.Registration;

namespace MC.Application.ModelDto.Registration
{
    public class PoliceVerificationDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
        public string PoliceStationName { get; set; } = string.Empty;
        public PoliceVerificationStatus VerificationStatus { get; set; }
        public DateTime? VerificationDate { get; set; }
        public string? VerificationRemarks { get; set; }
        public bool IsActive { get; set; }
    }
}
