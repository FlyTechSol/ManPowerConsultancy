using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Religion.Query.GetAll
{
    public class GetAllReligionQuery : IRequest<ApiResponse<PaginatedResponse<ReligionDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllReligionQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
