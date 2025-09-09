using MC.Application.Contracts.Persistence.Approval;
using MC.Persistence.DatabaseContext;
using MC.Domain.Entity.Approval;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Approval
{
    public class ApprovalStageRepository : GenericRepository<Domain.Entity.Approval.ApprovalStage>, IApprovalStageRepository
    {
        public ApprovalStageRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
      
        public async Task<IList<ApprovalStage>> GetWorkflowStagesAsync(Guid workflowId, CancellationToken cancellationToken)
        {
            return await _context.ApprovalStages
                .Where(s => s.WorkflowId == workflowId)
                .Include(s => s.Approvers)
                .OrderBy(s => s.Order)
                .ToListAsync(cancellationToken);
        }
    }
}
