using MediatR;

namespace MC.Application.Features.Registration.Family.Command.Delete
{
    public class DeleteFamilyCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
