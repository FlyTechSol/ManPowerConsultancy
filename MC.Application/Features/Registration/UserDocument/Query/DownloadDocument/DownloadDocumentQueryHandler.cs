using AutoMapper;
using MC.Application.Contracts.Persistence.FileHandling;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserDocument.Query.DownloadDocument
{
    public class DownloadDocumentQueryHandler : IRequestHandler<DownloadDocumentQuery, FileResponseDto>
    {
        private readonly IUserDocumentRepository _userDocumentRepository;
        private readonly IFileStorageService _fileStorageService;

        public DownloadDocumentQueryHandler(
            IUserDocumentRepository userDocumentRepository,
            IFileStorageService fileStorageService)
        {
            _userDocumentRepository = userDocumentRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<FileResponseDto> Handle(DownloadDocumentQuery request, CancellationToken cancellationToken)
        {
            var record = await _userDocumentRepository.GetByIdAsync(request.UserDocumentId, cancellationToken);

            if (record == null)
                throw new NotFoundException($"User document with id {request.UserDocumentId} not found", request.UserDocumentId);

            if (string.IsNullOrWhiteSpace(record.FilePath))
                throw new NotFoundException("No user document uploaded for this record", "User Document");

            // Delegate file retrieval to the storage service
            return await _fileStorageService.GetFileAsync(record.FilePath, cancellationToken);
        }
    }
}
