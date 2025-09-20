using MC.Domain.Base;
using MC.Domain.Entity.Master;

namespace MC.Domain.Entity.Registration
{
    public class UserDocument : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; } = null!;

        public Guid DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; } = null!;

        // file location
        public string FilePath { get; set; } = string.Empty;

        // optional extra fields
        public string? DocumentNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsVerified { get; set; } = false;
    }

}
