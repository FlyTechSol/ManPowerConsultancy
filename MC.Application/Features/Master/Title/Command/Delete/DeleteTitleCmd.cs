using MediatR;

namespace MC.Application.Features.Master.Title.Command.Delete
{
    public class DeleteTitleCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
