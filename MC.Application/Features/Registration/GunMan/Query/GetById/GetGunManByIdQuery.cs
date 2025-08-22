using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.GunMan.Query.GetById
{
    public record GetGunManByIdQuery(Guid Id) : IRequest<GunManDetailDto>;
}
