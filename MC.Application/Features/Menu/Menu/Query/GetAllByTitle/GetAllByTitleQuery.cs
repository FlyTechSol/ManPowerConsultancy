using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.Menu.Query.GetAllByTitle
{
    public record GetAllByTitleQuery : IRequest<List<MenuTitleDto>>;
}
