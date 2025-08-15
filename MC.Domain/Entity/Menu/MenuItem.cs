using MC.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Domain.Entity.Menu
{
    public class MenuItem : BaseEntity
    {
        public int MenuItemDisplayOrder { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
     
        public Guid MenuId { get; set; }
        public Menu? Menu { get; set; }
    }
}
