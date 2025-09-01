using MC.Domain.Base;
using MC.Domain.Entity.Identity;

namespace MC.Domain.Entity.Menu
{
    public class MenuItem : BaseEntity
    {
        public int MenuItemDisplayOrder { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        // Foreign key to Menu
        public Guid MenuId { get; set; }
        public Menu? Menu { get; set; }
        // Role-based control
        public Guid RoleId { get; set; }
        public ApplicationRole? Role { get; set; }
    }
}
