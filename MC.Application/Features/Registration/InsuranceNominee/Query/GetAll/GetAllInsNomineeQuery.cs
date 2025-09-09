using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.InsuranceNominee.Query.GetAll
{
    public class GetAllInsNomineeQuery : IRequest<ApiResponse<PaginatedResponse<InsuranceNomineeDetailDto>>>
    {
        public Guid UserProfileId { get; set; }
        public QueryParams QueryParams { get; set; }

        public GetAllInsNomineeQuery(Guid userProfileId, QueryParams queryParams)
        {
            UserProfileId = userProfileId;
            QueryParams = queryParams;
        }
    }
}
