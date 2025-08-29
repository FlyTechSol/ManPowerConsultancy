using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Branch.Query.GetAll
{
  public record GetAllBranchesQuery : IRequest<List<BranchDetailDto>>;
}
