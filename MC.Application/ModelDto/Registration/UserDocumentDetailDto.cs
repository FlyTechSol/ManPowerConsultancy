using MC.Application.ModelDto.Base;

namespace MC.Application.ModelDto.Registration
{
    public class UserDocumentDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
        public Guid DocumentTypeId { get; set; }
        public string DocumentType { get; set; } = null!;
        public string FilePath { get; set; } = string.Empty;
        public string? DocumentNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsVerified { get; set; } = false;
    }
}
