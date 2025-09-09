using MC.Application.Contracts.Persistence.Approval;
using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


namespace MC.Persistence.Repositories.Approval
{
    public class ApprovalWorkflowRepository : GenericRepository<Domain.Entity.Approval.ApprovalWorkflow>, IApprovalWorkflowRepository
    {
        public ApprovalWorkflowRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<ApprovalWorkflow?> GetWorkflowByCompanyAndTypeAsync(Guid companyId, WorkflowType workflowType, CancellationToken cancellationToken)
        {
            return await _context.ApprovalWorkflows
                .Include(w => w.Stages)
                .ThenInclude(s => s.Approvers)
                .FirstOrDefaultAsync(w => w.CompanyId == companyId && w.WorkflowType == workflowType, cancellationToken);
        }

        public async Task<IList<ApprovalWorkflow>> GetAllWorkflowsForCompanyAsync(Guid companyId, CancellationToken cancellationToken)
        {
            return await _context.ApprovalWorkflows
                .Where(w => w.CompanyId == companyId)
                .Include(w => w.Stages)
                .ThenInclude(s => s.Approvers)
                .OrderBy(w => w.WorkflowType) // optional: order by enum
                .ToListAsync(cancellationToken);
        }
    }
}
