using MC.Application.Contracts.Persistence.Approval;
using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Approval
{
    public class ApprovalRequestStageRepository : GenericRepository<ApprovalRequestStage>, IApprovalRequestStageRepository
    {
        public ApprovalRequestStageRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<IList<ApprovalRequestStage>> GetStagesByRequestIdAsync(Guid requestId, CancellationToken cancellationToken)
        {
            return await _context.ApprovalRequestStages
                .Where(s => s.RequestId == requestId)
                .Include(s => s.Stage)
                    .ThenInclude(st => st.Approvers)
                .Include(s => s.Actions)
                .OrderBy(s => s.Stage.Order)
                .ToListAsync(cancellationToken);
        }

        public async Task<ApprovalRequestStage?> GetCurrentStageAsync(Guid requestId, CancellationToken cancellationToken)
        {
            return await _context.ApprovalRequestStages
                .Where(s => s.RequestId == requestId && s.Status == StageStatus.Pending)
                .Include(s => s.Stage)
                    .ThenInclude(st => st.Approvers)
                .Include(s => s.Actions)
                .OrderBy(s => s.Stage.Order)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task UpdateStageStatusAsync(Guid requestStageId, StageStatus status, CancellationToken cancellationToken)
        {
            var stage = await _context.ApprovalRequestStages.FindAsync(requestStageId);
            if (stage != null)
            {
                stage.Status = status;
                stage.DateModified = DateTime.UtcNow;
                _context.Update(stage);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }

}
