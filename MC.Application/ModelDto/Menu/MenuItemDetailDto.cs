using MC.Application.ModelDto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.ModelDto.Menu
{
    public class MenuItemDetailDto : AuditableDto
    {
        public Guid Id { get; set; }
        public int MenuItemDisplayOrder { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public Guid MenuId { get; set; }
        public string MenuValue { get; set; } = string.Empty;
    }
}
