using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Designation.Query.GetAll
{
    public class GetAllDesignationQuery : IRequest<ApiResponse<PaginatedResponse<DesignationDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllDesignationQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
