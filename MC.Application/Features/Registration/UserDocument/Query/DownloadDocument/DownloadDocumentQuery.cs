using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserDocument.Query.DownloadDocument
{
    public record DownloadDocumentQuery(Guid UserDocumentId) : IRequest<FileResponseDto>;
}
