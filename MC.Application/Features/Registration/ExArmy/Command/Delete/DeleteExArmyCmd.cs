using MediatR;

namespace MC.Application.Features.Registration.ExArmy.Command.Delete
{
    public class DeleteExArmyCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
