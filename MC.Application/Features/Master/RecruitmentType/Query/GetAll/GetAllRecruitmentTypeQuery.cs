using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.RecruitmentType.Query.GetAll
{
    public class GetAllRecruitmentTypeQuery : IRequest<ApiResponse<PaginatedResponse<RecruitmentTypeDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllRecruitmentTypeQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
