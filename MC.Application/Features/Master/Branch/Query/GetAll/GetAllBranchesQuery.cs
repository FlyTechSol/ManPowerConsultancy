using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Branch.Query.GetAll
{
    public class GetAllBranchesQuery : IRequest<ApiResponse<PaginatedResponse<BranchDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllBranchesQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
