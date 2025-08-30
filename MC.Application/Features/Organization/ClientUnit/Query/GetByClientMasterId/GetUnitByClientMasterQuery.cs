using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Query.GetByClientMasterId
{
    public class GetUnitByClientMasterQuery : IRequest<ApiResponse<PaginatedResponse<UnitDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }
        public Guid ClientMasterId { get; set; }

        public GetUnitByClientMasterQuery(QueryParams queryParams, Guid clientMasterId)
        {
            QueryParams = queryParams;
            ClientMasterId = clientMasterId;
        }
    }
}
