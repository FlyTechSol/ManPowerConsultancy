using MC.Domain.Base;
using MC.Domain.Entity.Identity;

namespace MC.Domain.Entity.Navigation
{
    public class NavigationNodeRole : BaseEntity
    {
        public Guid NavigationNodeId { get; set; }
        public NavigationNode NavigationNode { get; set; } = null!;

        public Guid RoleId { get; set; }
        public ApplicationRole Role { get; set; } = null!;
    }
}
