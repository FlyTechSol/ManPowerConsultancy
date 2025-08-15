using MC.Application.ModelDto.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Contracts.Persistence.Menu
{
    public interface IMenuRepository : IGenericRepository<Domain.Entity.Menu.Menu>
    {
        Task<List<MenuDto>> GetAllDetailsAsync();
        Task<MenuDetailDto?> GetDetailsAsync(Guid id);
        Task<List<MenuDto>> GetAllMenuWithRoleName();
        Task<List<MenuTitleDto>> GetAllMenuTitleAsync();
        Task<bool> IsUnique(string title, Guid roleId);
        Task<bool> IsUniqueForUpdate(Guid id, string value, Guid roleId);
    }
}
