using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Command.Update
{
   public class UpdateBankAccountCmdHandler : IRequestHandler<UpdateBankAccountCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IAppLogger<UpdateBankAccountCmdHandler> _logger;

        public UpdateBankAccountCmdHandler(IMapper mapper, IBankAccountRepository bankAccountRepository, IAppLogger<UpdateBankAccountCmdHandler> logger)
        {
            _mapper = mapper;
            _bankAccountRepository = bankAccountRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateBankAccountCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _bankAccountRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateBankAccountCmdValidator(_bankAccountRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Entity.Registration.BankAccount), request.Id);
                throw new BadRequestException("Invalid bank account detail", validationResult);
            }

            if (request.IsActive)
            {
                var existingRecords = await _bankAccountRepository
                    .GetAllByUserProfileIdAsync(request.UserProfileId, cancellationToken);

                var recordssToDeactivate = existingRecords
                    .Where(a => a.Id != request.Id && a.IsActive)
                    .ToList();

                foreach (var item in recordssToDeactivate)
                {
                    item.IsActive = false;
                }

                if (recordssToDeactivate.Any())
                    await _bankAccountRepository.UpdateRangeAsync(recordssToDeactivate, cancellationToken);
            }
            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _bankAccountRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
