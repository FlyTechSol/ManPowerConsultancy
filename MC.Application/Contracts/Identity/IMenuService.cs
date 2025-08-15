using MC.Application.ModelDto.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Contracts.Identity
{
    public interface IMenuService
    {
        Task<List<MenuDto>> GetMenusForRolesAsync(IList<string> roles);
    }
}
