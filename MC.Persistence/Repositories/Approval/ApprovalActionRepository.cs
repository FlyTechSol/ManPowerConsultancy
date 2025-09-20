using MC.Application.Contracts.Persistence.Approval;
using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Approval
{
    public class ApprovalActionRepository : GenericRepository<Domain.Entity.Approval.ApprovalAction>, IApprovalActionRepository
    {
        public ApprovalActionRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<ApprovalAction> AddActionAsync(Guid approvalRequestStageId, Guid approverId, ActionType action, string? comments, CancellationToken cancellationToken)
        {
            var approvalAction = new ApprovalAction
            {
                Id = Guid.NewGuid(),
                RequestStageId = approvalRequestStageId,
                ApproverId = approverId,
                Action = action,
                Comments = comments,
                ActionDate = DateTime.UtcNow,
            };

            _context.ApprovalActions.Add(approvalAction);
            await _context.SaveChangesAsync(cancellationToken);

            return approvalAction;
        }

        public async Task<PaginatedResponse<ApprovalActionDto>?> GetActionsByRequestIdAsync(Guid approvalRequestId, QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.ApprovalActions
                .AsNoTracking()
                .Include(a => a.Approver)
                    .ThenInclude(a => a.UserProfile)
                .Include(a => a.RequestStage)
                .Where(a => a.RequestStage.ApprovalRequestId == approvalRequestId && !a.IsDeleted)
                .OrderBy(a => a.ActionDate);

            // Total count before pagination
            var totalCount = await query.CountAsync(cancellationToken);

            // Sorting
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                string column = queryParams.Column;
                string direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "";

                query = query.OrderBy($"{column} {direction}");
            }
            else
            {
                query = query.OrderBy(a => a.DateCreated); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<ApprovalActionDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }
        public async Task<PaginatedResponse<ApprovalActionDto>?> GetActionsByRequestStageIdAsync(Guid approvalRequestStageId, QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.ApprovalActions
                .AsNoTracking()
                .Include(a => a.Approver)
                    .ThenInclude(a=>a.UserProfile)
                .Where(a => a.RequestStageId == approvalRequestStageId && !a.IsDeleted)
                .OrderBy(a => a.ActionDate);

            // Total count before pagination
            var totalCount = await query.CountAsync(cancellationToken);

            // Sorting
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                string column = queryParams.Column;
                string direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "";

                query = query.OrderBy($"{column} {direction}");
            }
            else
            {
                query = query.OrderBy(a => a.DateCreated); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<ApprovalActionDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        private ApprovalActionDto MapToDto(Domain.Entity.Approval.ApprovalAction response)
        {
            return new ApprovalActionDto
            {
                Id = response.Id,
                RequestStageId = response.RequestStageId,
                ApproverId = response.ApproverId,
                ApproverName = response.Approver?.UserProfile != null
                    ? $"{response.Approver.UserProfile.FirstName} {response.Approver.UserProfile.LastName}"
                    : Defaults.Users.Unknown,
                Action = response.Action,
                Comments = response.Comments,
                ActionDate = response.ActionDate,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}
