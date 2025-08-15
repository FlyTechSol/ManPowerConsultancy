using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.ModelDto.Menu
{
    public class MenuDto
    {
        public Guid Id { get; set; }
        public int MenuDisplayOrder { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsParent { get; set; }
        public string NavigationURL { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public List<MenuItemDto> MenuItems { get; set; } = new List<MenuItemDto>();
    }
}
