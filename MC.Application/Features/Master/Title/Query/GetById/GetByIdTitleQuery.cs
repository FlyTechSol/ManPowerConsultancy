using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Title.Query.GetById
{
    public record GetByIdTitleQuery(Guid Id) : IRequest<TitleDetailDto>;
}
