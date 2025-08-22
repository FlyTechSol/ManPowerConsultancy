using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Bank.Command.Update
{
    public class UpdateBankCmdHandler : IRequestHandler<UpdateBankCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IBankRepository _bankRepository;
        private readonly IAppLogger<UpdateBankCmdHandler> _logger;

        public UpdateBankCmdHandler(IMapper mapper, IBankRepository bankRepository, IAppLogger<UpdateBankCmdHandler> logger)
        {
            _mapper = mapper;
            _bankRepository = bankRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateBankCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _bankRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateBankCmdValidator(_bankRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Bank), request.Id);
                throw new BadRequestException("Invalid bank type", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _bankRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
