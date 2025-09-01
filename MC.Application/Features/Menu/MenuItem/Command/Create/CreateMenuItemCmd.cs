using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Features.Menu.MenuItem.Command.Create
{
    public class CreateMenuItemCmd : IRequest<Guid>
    {
        public int MenuItemDisplayOrder { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        //public string Component { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
        public Guid MenuId { get; set; }
    }
}
