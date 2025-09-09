using MC.Application.Contracts.Persistence.Approval;
using MC.Domain.Entity.Approval;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Approval
{
    public class ApprovalStageApproverRepository : GenericRepository<ApprovalStageApprover>, IApprovalStageApproverRepository
    {
        public ApprovalStageApproverRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<IList<ApprovalStageApprover>> GetApproversByStageIdAsync(Guid stageId, CancellationToken cancellationToken)
        {
            return await _context.ApprovalStageApprovers
                .Where(a => a.StageId == stageId)
                .Include(a => a.User)
                .Include(a => a.Designation)
                .ToListAsync(cancellationToken);
        }
    }

}
