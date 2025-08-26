using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Document.Query.GetAllIdentityProof
{
   public record GetAllIdentityProofQuery : IRequest<List<DocumentDto>>;
}
