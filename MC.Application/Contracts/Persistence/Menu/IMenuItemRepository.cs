using MC.Application.ModelDto.Menu;
using MC.Domain.Entity.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Contracts.Persistence.Menu
{
    public interface IMenuItemRepository : IGenericRepository<MenuItem> 
    {
        Task<List<MenuItemDto>> GetAllDetailsAsync(CancellationToken cancellationToken);
        Task<MenuItemDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<List<MenuItemDto>> GetMenuItemByMenuIdAsync(Guid menuId, CancellationToken cancellationToken);
        Task<bool> IsUnique(string title, Guid menuId, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
    }
}
