using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.SecurityDeposit.Query.GetById
{
     public record GetSecurityDepositByIdQuery(Guid Id) : IRequest<SecurityDepositDetailDto>;
}
