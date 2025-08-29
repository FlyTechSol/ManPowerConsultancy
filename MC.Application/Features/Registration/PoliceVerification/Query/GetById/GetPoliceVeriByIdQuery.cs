using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PoliceVerification.Query.GetById
{
   public record GetPoliceVeriByIdQuery(Guid Id) : IRequest<PoliceVerificationDetailDto>;
}
