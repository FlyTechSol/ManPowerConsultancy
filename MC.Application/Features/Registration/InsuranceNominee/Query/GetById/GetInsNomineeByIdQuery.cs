using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.InsuranceNominee.Query.GetById
{
   public record GetInsNomineeByIdQuery(Guid Id) : IRequest<InsuranceNomineeDetailDto>;
}
