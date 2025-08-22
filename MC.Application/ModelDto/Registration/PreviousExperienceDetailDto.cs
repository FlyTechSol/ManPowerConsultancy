using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Registration
{
    public class PreviousExperienceDetailDto:AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
        public string? CompanyWorked { get; set; }
        public string? Place { get; set; }
        public string? Duration { get; set; }
        public string? ReasonForLeft { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? LeftDate { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
    }
}
