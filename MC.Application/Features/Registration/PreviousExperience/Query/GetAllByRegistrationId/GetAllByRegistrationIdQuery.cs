using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PreviousExperience.Query.GetAllByRegistrationId
{
   public record GetAllByRegistrationIdQuery(int RegistrationId) : IRequest<PreviousExperienceDetailDto>;
}
