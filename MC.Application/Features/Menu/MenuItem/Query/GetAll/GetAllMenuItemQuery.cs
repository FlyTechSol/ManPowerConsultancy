using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Query.GetAll
{
    public record GetAllMenuItemQuery : IRequest<List<MenuItemDto>>;
}
