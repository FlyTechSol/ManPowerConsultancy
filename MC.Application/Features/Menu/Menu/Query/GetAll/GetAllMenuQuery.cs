using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.Menu.Query.GetAll
{
  public record GetAllMenuQuery : IRequest<List<MenuDto>>;
}
