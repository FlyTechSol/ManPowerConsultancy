using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.SecurityDeposit.Query.GetByRegistrationId
{
   public record GetSecurityDepositByRegistrationIdQuery(int RegistrationId) : IRequest<SecurityDepositDetailDto>;
}
