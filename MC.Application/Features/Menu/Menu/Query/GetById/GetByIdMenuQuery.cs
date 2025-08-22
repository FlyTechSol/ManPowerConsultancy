using MC.Application.ModelDto.Menu;
using MediatR;

namespace MC.Application.Features.Menu.Menu.Query.GetById
{
    public record GetByIdMenuQuery(Guid Id) : IRequest<MenuDetailDto>;
}
