using MC.Application.Contracts.Persistence.Approval;
using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Approval
{
    public class ApprovalActionRepository : GenericRepository<Domain.Entity.Approval.ApprovalAction>, IApprovalActionRepository
    {
        public ApprovalActionRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<ApprovalAction> AddActionAsync(Guid requestStageId, Guid approverId, ActionType action, string? comments, CancellationToken cancellationToken)
        {
            var approvalAction = new ApprovalAction
            {
                Id = Guid.NewGuid(),
                RequestStageId = requestStageId,
                ApproverId = approverId,
                Action = action,
                Comments = comments,
                ActionDate = DateTime.UtcNow,
            };

            _context.ApprovalActions.Add(approvalAction);
            await _context.SaveChangesAsync(cancellationToken);

            return approvalAction;
        }

        public async Task<IList<ApprovalAction>> GetActionsByRequestStageIdAsync(Guid requestStageId, CancellationToken cancellationToken)
        {
            return await _context.ApprovalActions
                .Where(a => a.RequestStageId == requestStageId)
                .OrderBy(a => a.ActionDate)
                .ToListAsync(cancellationToken);
        }
    }
}
