using MediatR;

namespace MC.Application.Features.Registration.Communication.Command.Delete
{
    public class DeleteCommunicationCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
