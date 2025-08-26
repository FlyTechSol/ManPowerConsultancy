using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Resignation.Query.GetByRegistrationId
{
   public record GetByResignationIdQuery(int RegistrationId) : IRequest<ResignationDetailDto>;
}
