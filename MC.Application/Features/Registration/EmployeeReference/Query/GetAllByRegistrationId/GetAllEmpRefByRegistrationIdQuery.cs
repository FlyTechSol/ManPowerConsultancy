using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeReference.Query.GetAllByRegistrationId
{
   public record GetAllEmpRefByRegistrationIdQuery(int RegistrationId) : IRequest<EmployeeReferenceDetailDto>;
}
