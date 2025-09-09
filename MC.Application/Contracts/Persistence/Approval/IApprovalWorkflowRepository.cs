using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;
using MC.Domain.Entity.Organization;


namespace MC.Application.Contracts.Persistence.Approval
{
    public interface IApprovalWorkflowRepository : IGenericRepository<ApprovalWorkflow>
    {
        Task<ApprovalWorkflow?> GetWorkflowByCompanyAndTypeAsync(Guid companyId, WorkflowType workflowType, CancellationToken cancellationToken);
        Task<IList<ApprovalWorkflow>> GetAllWorkflowsForCompanyAsync(Guid companyId, CancellationToken cancellationToken);
    }
}
