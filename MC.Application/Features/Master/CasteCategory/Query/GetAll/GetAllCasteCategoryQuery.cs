using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.CasteCategory.Query.GetAll
{
    public class GetAllCasteCategoryQuery : IRequest<ApiResponse<PaginatedResponse<CasteCategoryDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllCasteCategoryQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
