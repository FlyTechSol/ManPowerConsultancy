using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Religion.Query.GetById
{
    public record GetByIdReligionQuery(Guid Id) : IRequest<ReligionDetailDto>;
}
