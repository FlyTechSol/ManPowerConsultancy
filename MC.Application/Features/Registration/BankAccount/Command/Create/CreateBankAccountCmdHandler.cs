using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Command.Create
{
    public class CreateBankAccountCmdHandler : IRequestHandler<CreateBankAccountCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IBankAccountRepository _bankAccountRepository;

        public CreateBankAccountCmdHandler(IMapper mapper, IBankAccountRepository bankAccountRepository)
        {
            _mapper = mapper;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<Guid> Handle(CreateBankAccountCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateBankAccountCmdValidator(_bankAccountRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid bank account record", validationResult);

            var existingRecords = await _bankAccountRepository
               .GetAllByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            foreach (var addr in existingRecords.Where(a => a.IsActive))
            {
                addr.IsActive = false;
            }
            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Registration.BankAccount>(request);
            recordToCreate.IsActive = true;
            // add to database
            await _bankAccountRepository.CreateBankAccountAsync(recordToCreate, request.PassbookUrl, cancellationToken);

            if (existingRecords.Any())
            {
                await _bankAccountRepository.UpdateRangeAsync(existingRecords, cancellationToken);
            }

            // retun record id
            return recordToCreate.Id;
        }
    }
}
