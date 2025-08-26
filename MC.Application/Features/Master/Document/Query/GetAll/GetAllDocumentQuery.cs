using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Document.Query.GetAll
{
    public record GetAllDocumentQuery : IRequest<List<DocumentDto>>;
}
