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
    public class ApprovalStageRepository : GenericRepository<Domain.Entity.Approval.ApprovalStage>, IApprovalStageRepository
    {
        public ApprovalStageRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<IList<ApprovalStage>> GetWorkflowStagesAsync(Guid approvalWorkflowId, CancellationToken cancellationToken)
        {
            return await _context.ApprovalStages
                .Where(s => s.ApprovalWorkflowId == approvalWorkflowId)
                .Include(s => s.Approvers)
                .OrderBy(s => s.Order)
                .ToListAsync(cancellationToken);
        }

        public async Task<ApprovalStagesDto?> GetApprovalStageByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.ApprovalStages
                .AsNoTracking()
                .Include(q => q.Workflow)
                    .ThenInclude(q => q.Company)
                .Include(s => s.Workflow)
                .Where(a => a.Id == id && !a.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<PaginatedResponse<ApprovalStagesDto>> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.ApprovalStages
                .Include(q => q.Workflow)
                    .ThenInclude(q => q.Company)
                .AsNoTracking()
                .Include(w => w.Workflow)
                .Where(q => !q.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    q.Workflow.WorkflowType.ToString().ToLower().Contains(search) ||
                    q.ApprovalMode.ToString().ToLower().Contains(search)
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
                query = query.OrderBy(a => a.Order); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<ApprovalStagesDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        private ApprovalStagesDto MapToDto(Domain.Entity.Approval.ApprovalStage response)
        {
            return new ApprovalStagesDto
            {
                Id = response.Id,
                ApprovalWorkflowId = response.ApprovalWorkflowId,
                ApprovalWorkflowName = EnumHelper.FormatWorkflowType(response.Workflow.WorkflowType) + " (" + response.Workflow.Company.CompanyName + ") " + response.Order,
                ApprovalWorkflowType = response.Workflow.WorkflowType,
                CompanyName = response.Workflow.Company.CompanyName,
                Order = response.Order,
                IsFinalStage = response.IsFinalStage,
                ApprovalMode = response.ApprovalMode,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
    }
}
