using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Communication.Query.GetById
{
   public record GetCommunicationByIdQuery(Guid Id) : IRequest<CommunicationDetailDto>;
}
