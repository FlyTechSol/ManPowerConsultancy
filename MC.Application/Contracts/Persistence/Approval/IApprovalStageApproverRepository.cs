using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MC.Domain.Entity.Approval;

namespace MC.Application.Contracts.Persistence.Approval
{
    public interface IApprovalStageApproverRepository : IGenericRepository<ApprovalStageApprover>
    {
        Task<PaginatedResponse<ApprovalStageApproverDto>> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<ApprovalStageApproverDto?> GetApprovalStageApproverByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IList<ApprovalStageApprover>> GetApproversByStageIdAsync(Guid approvalStageId, CancellationToken cancellationToken);
    }
}
