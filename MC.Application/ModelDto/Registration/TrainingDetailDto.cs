using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Registration
{
    public class TrainingDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
        public string TrainingName { get; set; } = string.Empty;
        public string? TrainingInstitute { get; set; }
        public DateTime? TrainingStartDate { get; set; }
        public DateTime? TrainingEndDate { get; set; }
        public string? TrainingRemarks { get; set; }
        public string? TrainingCertificateUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
