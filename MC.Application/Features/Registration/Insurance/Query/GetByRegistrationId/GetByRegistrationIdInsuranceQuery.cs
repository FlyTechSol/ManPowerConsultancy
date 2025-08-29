using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Insurance.Query.GetByRegistrationId
{
    public record GetByRegistrationIdInsuranceQuery(string RegistrationId) : IRequest<List<InsuranceDetailDto>>;
}
