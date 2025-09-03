using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserProfile.Query.GetAll
{
    public class GetAllUserProfilesQuery : IRequest<ApiResponse<PaginatedResponse<UserProfileDto>>>
    {
        public QueryParams QueryParams { get; set; }

        public GetAllUserProfilesQuery(QueryParams queryParams)
        {
            QueryParams = queryParams;
        }
    }
}
