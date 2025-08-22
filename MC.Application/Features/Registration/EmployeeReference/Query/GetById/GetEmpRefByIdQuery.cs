using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeReference.Query.GetById
{
   public record GetEmpRefByIdQuery(Guid Id) : IRequest<EmployeeReferenceDetailDto>;
}
