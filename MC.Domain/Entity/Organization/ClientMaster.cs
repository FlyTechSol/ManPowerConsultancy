using MC.Domain.Base;
using MC.Domain.Entity.Registration;

namespace MC.Domain.Entity.Organization
{
    public class ClientMaster : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;
        public string ClientName { get; set; } = string.Empty;
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public double ProjectCost { get; set; }
        public string ProjectLocation { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public ICollection<ClientUnit> Units { get; set; } = new List<ClientUnit>();
        public ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
    }
}
