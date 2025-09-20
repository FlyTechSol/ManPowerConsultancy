using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Contracts.UnitOfWork;
using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Approval
{
    internal class ApprovalService : IApprovalService
    {
        private readonly IApprovalActionRepository _actionRepo;
        private readonly IApprovalRequestStageRepository _stageRepo;
        private readonly IUnitOfWork _unitOfWork;

        public ApprovalService(
            IApprovalActionRepository actionRepo,
            IApprovalRequestStageRepository stageRepo,
            IUnitOfWork unitOfWork)
        {
            _actionRepo = actionRepo;
            _stageRepo = stageRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResponse<PendingApprovalStageDto>> GetPendingApprovalsForUserAsync(
                Guid userId,
                QueryParams queryParams,
                CancellationToken cancellationToken)
        {
            var stages = await _stageRepo.GetPendingStagesForApproverAsync(userId, cancellationToken);

            var query = stages.AsQueryable();

            // Apply search
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(s => s.Status.ToString().ToLower().Contains(search));
            }

            var totalCount = query.Count();

            // Apply sorting
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                string column = queryParams.Column;
                string direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "";
                query = query.OrderBy($"{column} {direction}");
            }
            else
            {
                query = query.OrderBy(s => s.DateCreated);
            }

            // Apply pagination
            var paged = query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToList();

            var dtos = paged.Select(s => new PendingApprovalStageDto
            {
                Id = s.Id,
                WorkflowName = s.Stage.Workflow.WorkflowType.ToString(),
                RequestedBy = s.Request.RequestedUser.UserName ?? string.Empty,
                StageOrder = s.Stage.Order,
                StageStatus = s.Status
            }).ToList();

            return new PaginatedResponse<PendingApprovalStageDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        public async Task ApproveAsync(Guid requestStageId, Guid approverId, string? comments, CancellationToken cancellationToken)
        {
            // 1. Load stage
            var stage = await _stageRepo.GetByIdAsync(requestStageId, cancellationToken);
            if (stage == null)
                throw new KeyNotFoundException("Approval stage not found.");

            // 2. Ensure user is an approver for this stage
            if (!stage.Stage.Approvers.Any(a => a.UserId == approverId))
                throw new UnauthorizedAccessException("You are not an approver for this stage.");

            // 3. Ensure previous stages are approved
            if (stage.Stage.Order > 1)
            {
                var prevStages = await _stageRepo.GetPreviousStagesAsync(stage.ApprovalRequestId, stage.Stage.Order, cancellationToken);
                if (prevStages.Any(s => s.Status != StageStatus.Approved))
                    throw new InvalidOperationException("Previous stages must be approved first.");
            }

            // 4. Record action
            await _actionRepo.AddActionAsync(requestStageId, approverId, ActionType.Approved, comments, cancellationToken);

            // 5. Update current stage status
            stage.Status = StageStatus.Approved;
            await _stageRepo.UpdateAsync(stage, cancellationToken);

            // 6. Flip next stage to Pending
            var nextStage = await _stageRepo.GetNextStageAsync(stage.ApprovalRequestId, stage.Stage.Order, cancellationToken);
            if (nextStage != null && nextStage.Status == StageStatus.NotStarted)
            {
                nextStage.Status = StageStatus.Pending;
                await _stageRepo.UpdateAsync(nextStage, cancellationToken);
            }

            // 7. Optionally update whole request status if this was last stage
            if (nextStage == null) // means last stage approved
            {
                stage.Request.Status = RequestStatus.Approved;
            }

            // 8. Save changes
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }


        public async Task RejectAsync(Guid requestStageId, Guid approverId, string? comments, CancellationToken cancellationToken)
        {
            var stage = await _stageRepo.GetByIdAsync(requestStageId, cancellationToken);
            if (stage == null)
                throw new KeyNotFoundException("Approval stage not found.");

            if (!stage.Stage.Approvers.Any(a => a.UserId == approverId))
                throw new UnauthorizedAccessException("You are not an approver for this stage.");

            await _actionRepo.AddActionAsync(requestStageId, approverId, ActionType.Rejected, comments, cancellationToken);

            stage.Status = StageStatus.Rejected;
            stage.Request.Status = RequestStatus.Rejected; // cascade reject whole request
            await _stageRepo.UpdateAsync(stage, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DelegateAsync(Guid requestStageId, Guid approverId, Guid delegateToUserId, string? comments, CancellationToken cancellationToken)
        {
            var stage = await _stageRepo.GetByIdAsync(requestStageId, cancellationToken);
            if (stage == null)
                throw new KeyNotFoundException("Approval stage not found.");

            if (!stage.Stage.Approvers.Any(a => a.UserId == approverId))
                throw new UnauthorizedAccessException("You are not an approver for this stage.");

            await _actionRepo.AddActionAsync(requestStageId, approverId, ActionType.Delegated, comments, cancellationToken);

            // Assign delegation
            stage.Stage.Approvers.Add(new ApprovalStageApprover
            {
                Id = Guid.NewGuid(),
                UserId = delegateToUserId,
                ApprovalStageId = stage.ApprovalStageId,
                IsMandatory = true // or false depending on your business rule
            });

            await _stageRepo.UpdateAsync(stage, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

