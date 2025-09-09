using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Family.Query.GetAll
{
    public class GetAllFamiliesQuery : IRequest<ApiResponse<PaginatedResponse<FamilyDetailDto>>>
    {
        public Guid UserProfileId { get; set; }
        public QueryParams QueryParams { get; set; }

        public GetAllFamiliesQuery(Guid userProfileId, QueryParams queryParams)
        {
            UserProfileId = userProfileId;
            QueryParams = queryParams;
        }
    }
}
