using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.ExArmy.Query.GetAllByUserProfileId
{
    public class GetAllByUserProfileIdQuery : IRequest<ApiResponse<PaginatedResponse<ExArmyDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }
        public Guid UserProfileId { get; set; }

        public GetAllByUserProfileIdQuery(Guid userProfileId, QueryParams queryParams)
        {
            UserProfileId = userProfileId;
            QueryParams = queryParams;
        }
    }
}
