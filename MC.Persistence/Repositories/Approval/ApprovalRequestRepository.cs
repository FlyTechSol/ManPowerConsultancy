using MC.Application.Contracts.Persistence.Approval;
using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Approval
{
    public class ApprovalRequestRepository : GenericRepository<Domain.Entity.Approval.ApprovalRequest>, IApprovalRequestRepository
    {
        public ApprovalRequestRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<ApprovalRequest> CreateApprovalRequestAsync(Guid approvalWorkflowId, Guid requestedBy, RequestType requestType, Guid requestEntityId, CancellationToken cancellationToken)
        {
            var request = new ApprovalRequest
            {
                Id = Guid.NewGuid(),
                ApprovalWorkflowId = approvalWorkflowId,
                RequestedBy = requestedBy,
                RequestType = requestType,
                RequestEntityId = requestEntityId,
                Status = RequestStatus.Pending,
            };

            _context.ApprovalRequests.Add(request);
            await _context.SaveChangesAsync(cancellationToken);

            return request;
        }
    }
}
