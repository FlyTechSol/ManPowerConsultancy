using MediatR;

namespace MC.Application.Features.Registration.PoliceVerification.Command.Delete
{
    public class DeletePoliceVeriCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
