using MC.Application.ModelDto.Base;
using MC.Domain.Entity.Enum.Registration;

namespace MC.Application.ModelDto.Registration
{
    public class EmployeeVerificationDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public VerificationType VerificationType { get; set; } //Address, CriminalRecord, Education, Employment, Reference , Other
        public string AgencyName { get; set; } = string.Empty;
        public DateTime InitiatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public VerificationStatus Status { get; set; }  //Pending, InProgress, Completed, Failed, Incomplete, OnHold, Other
        public VerificationResult? Result { get; set; } //Clear, Discrepancy Found, Not Verified, Other
        public string? AgencyReportUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
