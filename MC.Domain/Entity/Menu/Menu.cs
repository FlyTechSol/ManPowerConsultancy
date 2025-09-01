using MC.Domain.Base;
using MC.Domain.Entity.Identity;

namespace MC.Domain.Entity.Menu
{

    public class Menu : BaseEntity
    {
        public int MenuDisplayOrder { get; set; }
        public string Title { get; set; } = string.Empty;
        //public bool IsParent { get; set; }
        //public string NavigationURL { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        //public Guid RoleId { get; set; }

        //// Navigation properties
        //public ApplicationRole? Role { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
