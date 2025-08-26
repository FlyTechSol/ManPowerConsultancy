using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.InsuranceNominee.Query.GetAllByRegistrationId
{
   public record GetAllInsNomineeByRegIdQuery(int RegistrationId) : IRequest<InsuranceNomineeDetailDto>;
}
