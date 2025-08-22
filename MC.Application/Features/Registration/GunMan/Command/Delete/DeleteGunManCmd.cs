using MediatR;

namespace MC.Application.Features.Registration.GunMan.Command.Delete
{
    public class DeleteGunManCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
