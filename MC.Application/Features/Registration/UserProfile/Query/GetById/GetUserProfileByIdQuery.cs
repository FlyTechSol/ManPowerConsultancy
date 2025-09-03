using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserProfile.Query.GetById
{
    public record GetUserProfileByIdQuery(Guid Id) : IRequest<UserProfileDto>;
}
