using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.GunMan.Query.GetAllByRegistrationId
{
    public record GetAllGunManByRegIdQuery(string RegistrationId) : IRequest<List<GunManDetailDto>>;
}
