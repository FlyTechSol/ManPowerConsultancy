using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserAsset.Query.GetAllByUserProfileId
{
    public class GetAllByUserProfileQuery : IRequest<ApiResponse<PaginatedResponse<UserAssetDetailDto>>>
    {
        public QueryParams QueryParams { get; set; }
        public Guid UserProfileId { get; set; }

        public GetAllByUserProfileQuery(Guid userProfileId, QueryParams queryParams)
        {
            UserProfileId = userProfileId;
            QueryParams = queryParams;
        }
    }
}
