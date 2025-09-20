using MC.Domain.Base;
using MC.Domain.Entity.Registration;

namespace MC.Domain.Entity.Master
{
    public class Designation : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int? DisplayOrder { get; set; }

        public ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
    }
}
