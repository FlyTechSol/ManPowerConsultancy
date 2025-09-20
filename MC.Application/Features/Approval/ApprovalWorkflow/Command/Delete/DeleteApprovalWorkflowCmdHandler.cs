using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalWorkflow.Command.Delete
{
    public class DeleteApprovalWorkflowCmdHandler : IRequestHandler<DeleteApprovalWorkflowCmd, Unit>
    {
        private readonly IApprovalWorkflowRepository _approvalWorkflowRepository;

        public DeleteApprovalWorkflowCmdHandler(IApprovalWorkflowRepository approvalWorkflowRepository)
        {
            _approvalWorkflowRepository = approvalWorkflowRepository;
        }

        public async Task<Unit> Handle(DeleteApprovalWorkflowCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _approvalWorkflowRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(ApprovalWorkflow), request.Id);

            // remove from database
            await _approvalWorkflowRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
