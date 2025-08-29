using MC.Domain.Entity.Enum.Common;
using MediatR;

namespace MC.Application.Features.Master.DocumentType.Command.Create
{
    public class CreateDocumentTypeCmd : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty; 
        public string? Description { get; set; }
        public DocumentPurpose Purpose { get; set; }
    }
}
