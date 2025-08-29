using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Resignation.Query.GetByRegistrationId
{
   public record GetByResignationIdQuery(string RegistrationId) : IRequest<ResignationDetailDto>;
}
