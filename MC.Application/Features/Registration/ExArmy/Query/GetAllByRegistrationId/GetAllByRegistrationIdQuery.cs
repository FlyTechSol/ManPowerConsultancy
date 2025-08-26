using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.ExArmy.Query.GetAllByRegistrationId
{
  public record GetAllByRegistrationIdQuery(int RegistrationId) : IRequest<ExArmyDetailDto>;
}
