using AutoMapper;
using MC.Application.Contracts.Persistence.FileHandling;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.ExArmy.Query.DownloadExArmyCertificate
{
    public class DownloadExArmyCertQueryHandler : IRequestHandler<DownloadExArmyCertQuery, FileResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IExArmyRepository _exArmyRepository;
        private readonly IFileStorageService _fileStorageService;

        public DownloadExArmyCertQueryHandler(
            IExArmyRepository exArmyRepository,
            IMapper mapper,
            IFileStorageService fileStorageService)
        {
            _exArmyRepository = exArmyRepository;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        public async Task<FileResponseDto> Handle(DownloadExArmyCertQuery request, CancellationToken cancellationToken)
        {
            var record = await _exArmyRepository.GetByIdAsync(request.ExArmyId, cancellationToken);

            if (record == null)
                throw new NotFoundException($"Ex army with id {request.ExArmyId} not found", request.ExArmyId);

            if (string.IsNullOrWhiteSpace(record.DischargeCertificateUrl))
                throw new NotFoundException("No certificate uploaded for this record", "Ex Army certificate");

            // Delegate file retrieval to the storage service
            return await _fileStorageService.GetFileAsync(record.DischargeCertificateUrl, cancellationToken);
        }
    }
}
