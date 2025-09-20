using AutoMapper;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalWorkflow.Command.Update
{
    public class UpdateApprovalWorkflowCmdHandler : IRequestHandler<UpdateApprovalWorkflowCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalWorkflowRepository _approvalWorkflowRepository;
        private readonly IAppLogger<UpdateApprovalWorkflowCmdHandler> _logger;

        public UpdateApprovalWorkflowCmdHandler(IMapper mapper, IApprovalWorkflowRepository approvalWorkflowRepository, IAppLogger<UpdateApprovalWorkflowCmdHandler> logger)
        {
            _mapper = mapper;
            _approvalWorkflowRepository = approvalWorkflowRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateApprovalWorkflowCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _approvalWorkflowRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateApprovalWorkflowCmdValidator(_approvalWorkflowRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(ApprovalWorkflow), request.Id);
                throw new BadRequestException("Invalid approval workflow", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _approvalWorkflowRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
