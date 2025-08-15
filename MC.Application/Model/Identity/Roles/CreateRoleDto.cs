using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Model.Identity.Roles
{
    public class CreateRoleDto
    {
        public int DisplayOrder { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
