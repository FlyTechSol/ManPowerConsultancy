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
        Task<List<MenuDto>> GetAllDetailsAsync(CancellationToken cancellationToken);
        Task<MenuDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<List<MenuDto>> GetAllMenuWithRoleName(CancellationToken cancellationToken);
        Task<List<MenuTitleDto>> GetAllMenuTitleAsync(CancellationToken cancellationToken);
        Task<bool> IsUnique(string title, Guid roleId, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string value, Guid roleId, CancellationToken cancellationToken);
    }
}
