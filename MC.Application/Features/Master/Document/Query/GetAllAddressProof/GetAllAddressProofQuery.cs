using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Document.Query.GetAllAddressProof
{
    public record GetAllAddressProofQuery : IRequest<List<DocumentDto>>;
}
