using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStage.Command.Delete
{
    public class DeleteApprovalStageCmdHandler : IRequestHandler<DeleteApprovalStageCmd, Unit>
    {
        private readonly IApprovalStageRepository _approvalStageRepository;

        public DeleteApprovalStageCmdHandler(IApprovalStageRepository approvalStageRepository)
        {
            _approvalStageRepository = approvalStageRepository;
        }

        public async Task<Unit> Handle(DeleteApprovalStageCmd request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var recordToDelete = await _approvalStageRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (recordToDelete == null)
                throw new NotFoundException(nameof(ApprovalStage), request.Id);

            // remove from database
            await _approvalStageRepository.SoftDeleteAsync(request.Id, cancellationToken);

            // retun record id - null return 
            return Unit.Value;
        }
    }
}
