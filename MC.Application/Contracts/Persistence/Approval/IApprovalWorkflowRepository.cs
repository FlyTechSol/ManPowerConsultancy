using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Application.Contracts.Persistence.Approval
{
    public interface IApprovalWorkflowRepository : IGenericRepository<ApprovalWorkflow>
    {
        Task<ApprovalWorkflow?> GetWorkflowByCompanyAndTypeAsync(Guid companyId, WorkflowType workflowType, CancellationToken cancellationToken);
        Task<IList<ApprovalWorkflow>> GetAllWorkflowsForCompanyAsync(Guid companyId, CancellationToken cancellationToken);
        Task<ApprovalWorkflowDto?> GetApprovalWorkflowByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<PaginatedResponse<ApprovalWorkflowDto>> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<bool> IsWorkflowUniqueAsync(Guid companyId, WorkflowType workflowType, CancellationToken cancellationToken);
        Task<bool> IsWorkflowUniqueForUpdateAsync(Guid id, Guid companyId, WorkflowType workflowType, CancellationToken cancellationToken);
    }
}
