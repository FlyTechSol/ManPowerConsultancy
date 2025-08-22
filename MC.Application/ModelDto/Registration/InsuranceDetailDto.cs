using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Registration
{
    public class InsuranceDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
        public string InsuranceCompanyName { get; set; } = string.Empty;
        public string PolicyNumber { get; set; } = string.Empty;
        public DateTime? PolicyStartDate { get; set; }
        public DateTime? PolicyEndDate { get; set; }
        public string? PolicyRemarks { get; set; }
        public bool IsActive { get; set; }
    }
}
