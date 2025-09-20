using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStageApprover.Command.Delete
{
    public class DeleteApprovalStageApproverCmdHandler : IRequestHandler<DeleteApprovalStageApproverCmd, Unit>
    {
        private readonly IApprovalStageApproverRepository _approvalStageApproverRepository;

        public DeleteApprovalStageApproverCmdHandler(IApprovalStageApproverRepository approvalStageApproverRepository)
        {
            _approvalStageApproverRepository = approvalStageApproverRepository;
        }

        public async Task<Unit> Handle(DeleteApprovalStageApproverCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _approvalStageApproverRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(ApprovalStageApprover), request.Id);

            // remove from database
            await _approvalStageApproverRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
