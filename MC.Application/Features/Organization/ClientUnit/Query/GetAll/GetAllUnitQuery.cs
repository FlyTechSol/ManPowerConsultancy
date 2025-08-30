using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Organization;
using MediatR;

namespace MC.Application.Features.Organization.ClientUnit.Query.GetAll
{
    public class GetAllUnitQuery : IRequest<ApiResponse<PaginatedResponse<UnitDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllUnitQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
