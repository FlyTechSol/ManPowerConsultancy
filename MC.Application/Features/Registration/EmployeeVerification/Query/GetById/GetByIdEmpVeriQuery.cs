using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeVerification.Query.GetById
{
    public record GetByIdEmpVeriQuery(Guid Id) : IRequest<EmployeeVerificationDetailDto>;
}
