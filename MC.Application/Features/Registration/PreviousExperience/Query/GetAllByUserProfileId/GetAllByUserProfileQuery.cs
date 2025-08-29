using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PreviousExperience.Query.GetAllByUserProfileId
{
    public record GetAllByUserProfileQuery(Guid UserProfileId) : IRequest<List<PreviousExperienceDetailDto>>;
}
