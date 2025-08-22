using MediatR;

namespace MC.Application.Features.Menu.MenuItem.Command.Delete
{
   public class DeleteMenuItemCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
