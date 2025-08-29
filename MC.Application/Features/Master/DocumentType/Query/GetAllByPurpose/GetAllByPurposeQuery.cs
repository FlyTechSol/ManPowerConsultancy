using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Enum.Common;
using MediatR;

namespace MC.Application.Features.Master.DocumentType.Query.GetAllByPurpose
{
    public record GetAllByPurposeQuery(DocumentPurpose purpose) : IRequest<List<DocumentTypeDto>>;
}
