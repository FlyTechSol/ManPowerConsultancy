using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Query.GetMenuItemByMenuId
{
   public record GetMenuItemByMenuIdQuery(Guid MenuId) : IRequest<List<MenuItemDto>>;
}
