using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.DocumentType.Query.GetAll
{
    public record GetAllDocumentTypeQuery : IRequest<List<DocumentTypeDto>>;
}
