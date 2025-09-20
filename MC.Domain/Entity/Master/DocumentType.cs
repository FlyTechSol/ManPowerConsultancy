using MC.Domain.Base;
using MC.Domain.Entity.Enum.Common;
using MC.Domain.Entity.Registration;

namespace MC.Domain.Entity.Master
{
    public class DocumentType : BaseEntity
    {
        public string Name { get; set; } = string.Empty; // e.g., "Aadhaar Card"
        public string? Description { get; set; }
        public DocumentPurpose Purpose { get; set; } // Enum with [Flags]
        public ICollection<UserDocument> UserDocuments { get; set; } = new List<UserDocument>();
    }
}
