using MediatR;

namespace MC.Application.Features.Master.DocumentType.Command.Delete
{
    public class DeleteDocumentTypeCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
