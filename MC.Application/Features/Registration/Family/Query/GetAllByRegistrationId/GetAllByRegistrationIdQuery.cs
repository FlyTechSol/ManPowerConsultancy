using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Family.Query.GetAllByRegistrationId
{
   public record GetAllByRegistrationIdQuery(string RegistrationId) : IRequest<FamilyDetailDto>;
}
