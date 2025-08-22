using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Features.Menu.Menu.Command.Create
{
    public class CreateMenuCmd : IRequest<Guid>
    {
        public int MenuDisplayOrder { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsParent { get; set; }
        public string NavigationURL { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public string Component { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
    }
}
