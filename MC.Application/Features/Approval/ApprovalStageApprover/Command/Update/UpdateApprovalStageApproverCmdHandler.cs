using AutoMapper;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStageApprover.Command.Update
{
    public class UpdateApprovalStageApproverCmdHandler : IRequestHandler<UpdateApprovalStageApproverCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IApprovalStageApproverRepository _approvalStageApproverRepository;

        public UpdateApprovalStageApproverCmdHandler(IMapper mapper, IApprovalStageApproverRepository approvalStageApproverRepository)
        {
            _mapper = mapper;
            _approvalStageApproverRepository = approvalStageApproverRepository;
        }

        public async Task<Unit> Handle(UpdateApprovalStageApproverCmd request, CancellationToken cancellationToken)
        {
            var recordUpdateRequest = await _approvalStageApproverRepository.GetByIdAsync(request.Id, cancellationToken);

            if (recordUpdateRequest is null)
                throw new NotFoundException(nameof(recordUpdateRequest), request.Id);

            // Validate incoming data
            var validator = new UpdateApprovalStageApproverCmdValidator(_approvalStageApproverRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid approval stage approver record", validationResult);
            }

            // convert to domain entity object
            var recordToUpdate = _mapper.Map(request, recordUpdateRequest);

            // add to database
            await _approvalStageApproverRepository.UpdateAsync(recordToUpdate, cancellationToken);

            // return Unit value
            return Unit.Value;
        }
    }
}
