using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserProfile.Query.GetByRegistrationId
{
    public record GetUserProfileByRegistrationIdQuery(string RegistrationId) : IRequest<UserProfileDto>;
}
