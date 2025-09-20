using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;

namespace MC.Application.Contracts.Persistence.Approval
{
    public interface IApprovalRequestRepository : IGenericRepository<ApprovalRequest>
    {
        Task<ApprovalRequest> CreateApprovalRequestAsync(Guid approvalWorkflowId, Guid requestedBy, RequestType requestType, Guid requestEntityId, CancellationToken cancellationToken);
    }
}
