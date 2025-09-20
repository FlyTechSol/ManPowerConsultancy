using MC.Application.Contracts.Persistence.Approval;
using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MC.Domain.Entity.Approval;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Approval
{
    public class ApprovalStageApproverRepository : GenericRepository<ApprovalStageApprover>, IApprovalStageApproverRepository
    {
        public ApprovalStageApproverRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<IList<ApprovalStageApprover>> GetApproversByStageIdAsync(Guid approvalStageId, CancellationToken cancellationToken)
        {
            return await _context.ApprovalStageApprovers
                .Where(a => a.ApprovalStageId == approvalStageId)
                .Include(w => w.Company)   // <-- navigation property
                .Include(w => w.Role)      // <-- navigation property
                .Include(w => w.User)
                .ToListAsync(cancellationToken);
        }

        public async Task<ApprovalStageApproverDto?> GetApprovalStageApproverByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.ApprovalStageApprovers
                .AsNoTracking()
                .Include(w => w.Stage)
                    .ThenInclude(w => w.Workflow)
                .Include(w => w.Company)   // <-- navigation property
                .Include(w => w.Role)      // <-- navigation property
                .Include(w => w.User)
                    .ThenInclude(w => w.UserProfile)
                .Where(a => a.Id == id && !a.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<PaginatedResponse<ApprovalStageApproverDto>> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.ApprovalStageApprovers
                .AsNoTracking()
                .Include(w => w.Stage)
                    .ThenInclude(w => w.Workflow)
                .Include(w => w.Company)   // <-- navigation property
                .Include(w => w.Role)      // <-- navigation property
                .Include(w => w.User)
                    .ThenInclude(w => w.UserProfile)
                .Where(w => !w.IsDeleted);

            // Search filter
            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                q.User != null &&
                 q.User.UserProfile != null &&
                 (
                     q.User.UserProfile.FirstName.ToLower().Contains(search) ||
                     (q.User.UserProfile.LastName != null && q.User.UserProfile.LastName.ToLower().Contains(search))
                 )
                );
            }

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

            return new PaginatedResponse<ApprovalStageApproverDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        private ApprovalStageApproverDto MapToDto(Domain.Entity.Approval.ApprovalStageApprover response)
        {
            return new ApprovalStageApproverDto
            {
                Id = response.Id,
                ApprovalStageId = response.ApprovalStageId,
                ApprovalStageName = response.Stage.Workflow.WorkflowType.ToString() + " (" + response.Stage.ApprovalMode + ")",
                CompanyId = response.CompanyId,
                CompanyName = response.Company?.CompanyName,
                RoleId = response.RoleId,
                RoleName = response.Role?.Name,
                UserId = response.UserId,
                UserName = response.User?.UserProfile?.FirstName ?? string.Empty,
                IsMandatory = response.IsMandatory,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
    }

}
