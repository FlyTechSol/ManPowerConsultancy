using MediatR;

namespace MC.Application.Features.Registration.Address.Command.Delete
{
    public class DeleteAddressCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
