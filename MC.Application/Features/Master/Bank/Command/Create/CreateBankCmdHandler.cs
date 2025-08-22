using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Bank.Command.Create
{
    public class CreateBankCmdHandler : IRequestHandler<CreateBankCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IBankRepository _bankRepository;

        public CreateBankCmdHandler(IMapper mapper, IBankRepository bankRepository)
        {
            _mapper = mapper;
            _bankRepository = bankRepository;
        }

        public async Task<Guid> Handle(CreateBankCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateBankCmdValidator(_bankRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid bank type", validationResult);

            // convert to domain entity object
            var recordToCreate = _mapper.Map<Domain.Entity.Master.Bank>(request);

            await _bankRepository.CreateAsync(recordToCreate, cancellationToken);

            // retun record id
            return recordToCreate.Id;
        }
    }
}
