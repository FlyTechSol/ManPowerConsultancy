using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PoliceVerification.Query.GetByRegistrationId
{
    public record GetPoliceVeriByRegistrationIdQuery(string RegistrationId) : IRequest<PoliceVerificationDetailDto>;
}
