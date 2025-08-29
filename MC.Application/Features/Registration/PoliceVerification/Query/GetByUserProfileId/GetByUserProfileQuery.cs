using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PoliceVerification.Query.GetByUserProfileId
{
    public record GetByUserProfileQuery(Guid UserProfileId) : IRequest<PoliceVerificationDetailDto>;
}
