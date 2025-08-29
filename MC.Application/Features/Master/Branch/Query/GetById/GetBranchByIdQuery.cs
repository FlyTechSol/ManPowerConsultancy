using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Branch.Query.GetById
{
     public record GetBranchByIdQuery(Guid Id) : IRequest<BranchDetailDto>;
}
