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
        public async Task<ApprovalRequest> CreateApprovalRequestAsync(Guid workflowId, Guid requestedBy, RequestType requestType, Guid requestEntityId, CancellationToken cancellationToken)
        {
            var request = new ApprovalRequest
            {
                Id = Guid.NewGuid(),
                WorkflowId = workflowId,
                RequestedBy = requestedBy,
                RequestType = requestType,
                RequestEntityId = requestEntityId,
                Status = RequestStatus.Pending,
            };

            _context.ApprovalRequests.Add(request);
            await _context.SaveChangesAsync(cancellationToken);

            return request;
        }

        public async Task AddApprovalRequestStagesAsync(ApprovalRequest request, IEnumerable<ApprovalStage> stages, CancellationToken cancellationToken)
        {
            var requestStages = stages.Select(s => new ApprovalRequestStage
            {
                Id = Guid.NewGuid(),
                RequestId = request.Id,
                StageId = s.Id,
                Status = StageStatus.Pending,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            });

            _context.ApprovalRequestStages.AddRange(requestStages);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
