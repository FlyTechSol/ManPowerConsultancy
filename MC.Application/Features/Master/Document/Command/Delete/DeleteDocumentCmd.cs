using MediatR;

namespace MC.Application.Features.Master.Document.Command.Delete
{
    public class DeleteDocumentCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
