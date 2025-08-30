using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Gender.Query.GetAll
{
    public class GetAllGenderQuery : IRequest<ApiResponse<PaginatedResponse<GenderDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllGenderQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
