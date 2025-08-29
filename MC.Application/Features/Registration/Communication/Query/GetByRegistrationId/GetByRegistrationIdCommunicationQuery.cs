using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Communication.Query.GetByRegistrationId
{
    public record GetByRegistrationIdCommunicationQuery(string RegistrationId) : IRequest<CommunicationDetailDto>;
}
