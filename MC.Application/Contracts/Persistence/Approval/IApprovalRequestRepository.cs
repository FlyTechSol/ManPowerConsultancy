using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Application.Contracts.Persistence.Approval
{
    public interface IApprovalRequestRepository : IGenericRepository<ApprovalRequest>
    {
        Task<ApprovalRequest> CreateApprovalRequestAsync(Guid workflowId, Guid requestedBy, RequestType requestType, Guid requestEntityId, CancellationToken cancellationToken);
        Task AddApprovalRequestStagesAsync(ApprovalRequest request, IEnumerable<ApprovalStage> stages, CancellationToken cancellationToken);
    }
}
