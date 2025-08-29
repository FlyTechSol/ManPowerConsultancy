using MC.Domain.Base;
using MC.Domain.Entity.Master;
using MC.Domain.Entity.Registration;

namespace MC.Domain.Entity.Common
{
    public class UploadedDocument : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; } = null!;

        public Guid DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; } = null!;

        public string FilePath { get; set; } = string.Empty;
        public DateTime UploadedOn { get; set; } = DateTime.UtcNow;
    }
}
