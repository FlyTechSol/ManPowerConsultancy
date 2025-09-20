using AutoMapper;
using MC.Application.Contracts.Persistence.FileHandling;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.EmployeeVerification.Query.DownloadAgencyCertificate
{
    public class DownloadAgencyCertificateQueryHandler : IRequestHandler<DownloadAgencyCertificateQuery, FileResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeVerificationRepository _employeeVerificationRepository;
        private readonly IFileStorageService _fileStorageService;

        public DownloadAgencyCertificateQueryHandler(
            IEmployeeVerificationRepository employeeVerificationRepository,
            IMapper mapper,
            IFileStorageService fileStorageService)
        {
            _employeeVerificationRepository = employeeVerificationRepository;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        public async Task<FileResponseDto> Handle(DownloadAgencyCertificateQuery request, CancellationToken cancellationToken)
        {
            var record = await _employeeVerificationRepository.GetByIdAsync(request.EmpVerificationId, cancellationToken);

            if (record == null)
                throw new NotFoundException($"Employee verification with id {request.EmpVerificationId} not found", request.EmpVerificationId);

            if (string.IsNullOrWhiteSpace(record.AgencyReportUrl))
                throw new NotFoundException("No certificate uploaded for this record", "Ex Army certificate");

            // Delegate file retrieval to the storage service
            return await _fileStorageService.GetFileAsync(record.AgencyReportUrl, cancellationToken);
        }
    }
}
