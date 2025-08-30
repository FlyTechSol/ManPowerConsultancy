using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Category.Query.GetAll
{
    public class GetAllCategoriesQuery : IRequest<ApiResponse<PaginatedResponse<CategoryDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllCategoriesQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
