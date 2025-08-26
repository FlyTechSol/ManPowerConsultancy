using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Document.Query.GetAllAgeProof
{
   public record GetAllAgeProofQuery : IRequest<List<DocumentDto>>;
}
