using MC.Domain.Base;

namespace MC.Domain.Entity.Navigation
{
    public class NavigationNode : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid? ParentId { get; set; }
        public NavigationNode? Parent { get; set; }
        public ICollection<NavigationNode> Children { get; set; } = new List<NavigationNode>();

        public ICollection<NavigationNodeRole> NavigationNodeRoles { get; set; } = new List<NavigationNodeRole>();
    }
}
