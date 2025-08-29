using MC.Domain.Entity.Enum.Common;
using MediatR;

namespace MC.Application.Features.Master.DocumentType.Command.Update
{
    public class UpdateDocumentTypeCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty; // e.g., "Aadhaar Card"
        public string? Description { get; set; }
        public DocumentPurpose Purpose { get; set; }
    }
}
