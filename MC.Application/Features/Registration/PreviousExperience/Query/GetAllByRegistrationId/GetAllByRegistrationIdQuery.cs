using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PreviousExperience.Query.GetAllByRegistrationId
{
   public record GetAllByRegistrationIdQuery(string RegistrationId) : IRequest<PreviousExperienceDetailDto>;
}
