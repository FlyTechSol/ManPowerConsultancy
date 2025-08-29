using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Branch.Command.Update
{
    public class UpdateBranchCmdHandler : IRequestHandler<UpdateBranchCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;
        private readonly IAppLogger<UpdateBranchCmdHandler> _logger;

        public UpdateBranchCmdHandler(IMapper mapper, IBranchRepository branchRepository, IAppLogger<UpdateBranchCmdHandler> logger)
        {
            _mapper = mapper;
            _branchRepository = branchRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateBranchCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _branchRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateBranchCmdValidator(_branchRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Branch), request.Id);
                throw new BadRequestException("Invalid branch type", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _branchRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
