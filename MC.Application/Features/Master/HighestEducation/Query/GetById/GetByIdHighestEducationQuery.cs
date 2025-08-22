using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.HighestEducation.Query.GetById
{
    public record GetByIdHighestEducationQuery(Guid Id) : IRequest<HighestEducationDetailDto>;
}
