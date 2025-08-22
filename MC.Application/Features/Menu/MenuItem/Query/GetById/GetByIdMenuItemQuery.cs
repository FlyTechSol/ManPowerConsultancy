using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Query.GetById
{
   public record GetByIdMenuItemQuery(Guid Id) : IRequest<MenuItemDetailDto>;
}
