using MC.Domain.Base;
using MC.Domain.Entity.Registration;

namespace MC.Domain.Entity.Organization
{
    public class ClientUnit : BaseEntity
    {
        public Guid ClientMasterId { get; set; }
        public ClientMaster ClientMaster { get; set; } = null!;
        public string UnitName { get; set; } = string.Empty;
        public string UnitLocation { get; set; } = string.Empty;
        public int MaxHeadCount { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
    }
}
