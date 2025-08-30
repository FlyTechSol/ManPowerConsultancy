using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.HighestEducation.Query.GetAll
{
    public class GetAllHighestEducationQuery : IRequest<ApiResponse<PaginatedResponse<HighestEducationDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllHighestEducationQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
