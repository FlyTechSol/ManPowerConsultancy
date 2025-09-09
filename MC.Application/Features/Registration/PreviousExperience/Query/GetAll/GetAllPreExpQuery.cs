using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PreviousExperience.Query.GetAll
{
    public class GetAllPreExpQuery : IRequest<ApiResponse<PaginatedResponse<PreviousExperienceDetailDto>>>
    {
        public Guid UserProfileId { get; set; }
        public QueryParams QueryParams { get; set; }

        public GetAllPreExpQuery(Guid userProfileId, QueryParams queryParams)
        {
            UserProfileId = userProfileId;
            QueryParams = queryParams;
        }
    }
}
