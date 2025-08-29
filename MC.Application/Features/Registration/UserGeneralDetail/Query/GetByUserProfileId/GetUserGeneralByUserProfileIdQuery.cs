using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserGeneralDetail.Query.GetByUserProfileId
{
    public record GetUserGeneralByUserProfileIdQuery(Guid UserProfileId) : IRequest<UserGeneralDetailDto>;
}
