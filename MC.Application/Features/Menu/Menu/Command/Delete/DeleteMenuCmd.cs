using MediatR;

namespace MC.Application.Features.Menu.Menu.Command.Delete
{
    public class DeleteMenuCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
