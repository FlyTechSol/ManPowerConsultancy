using AutoMapper;
using MC.Application.Contracts.Persistence.FileHandling;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Query.DownloadBankAccount
{
    public class DownloadPassbookQueryHandler : IRequestHandler<DownloadPassbookQuery, FileResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IFileStorageService _fileStorageService;

        public DownloadPassbookQueryHandler(
            IBankAccountRepository bankAccountRepository,
            IMapper mapper,
            IFileStorageService fileStorageService)
        {
            _bankAccountRepository = bankAccountRepository;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        public async Task<FileResponseDto> Handle(DownloadPassbookQuery request, CancellationToken cancellationToken)
        {
            var bankAccount = await _bankAccountRepository.GetByIdAsync(request.BankAccountId, cancellationToken);

            if (bankAccount == null)
                throw new NotFoundException($"Bank account with id {request.BankAccountId} not found", request.BankAccountId);

            if (string.IsNullOrWhiteSpace(bankAccount.PassbookUrl))
                throw new NotFoundException("No passbook uploaded for this account", "Passbook");

            // Delegate file retrieval to the storage service
            return await _fileStorageService.GetFileAsync(bankAccount.PassbookUrl, cancellationToken);
        }
    }

}
