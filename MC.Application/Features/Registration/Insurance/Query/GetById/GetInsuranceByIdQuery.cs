using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Insurance.Query.GetById
{
  public record GetInsuranceByIdQuery(Guid Id) : IRequest<InsuranceDetailDto>;
}
