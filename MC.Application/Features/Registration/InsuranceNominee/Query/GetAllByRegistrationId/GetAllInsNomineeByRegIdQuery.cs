using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.InsuranceNominee.Query.GetAllByRegistrationId
{
   public record GetAllInsNomineeByRegIdQuery(string RegistrationId) : IRequest<List<InsuranceNomineeDetailDto>>;
}
