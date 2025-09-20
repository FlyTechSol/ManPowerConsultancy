using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MC.Domain.Entity.Approval;

namespace MC.Application.Contracts.Persistence.Approval
{
    public interface IApprovalStageRepository : IGenericRepository<ApprovalStage>
    {
        Task<IList<ApprovalStage>> GetWorkflowStagesAsync(Guid approvalWorkflowId, CancellationToken cancellationToken);
        Task<ApprovalStagesDto?> GetApprovalStageByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<PaginatedResponse<ApprovalStagesDto>> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken);
    }
}
