using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Document.Query.GetAllQualificationProof
{
   public record GetAllQualificationProofQuery : IRequest<List<DocumentDto>>;
}
