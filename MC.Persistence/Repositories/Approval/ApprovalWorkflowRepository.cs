using MC.Application.Contracts.Persistence.Approval;
using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


namespace MC.Persistence.Repositories.Approval
{
    public class ApprovalWorkflowRepository : GenericRepository<Domain.Entity.Approval.ApprovalWorkflow>, IApprovalWorkflowRepository
    {
        public ApprovalWorkflowRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<ApprovalWorkflow?> GetWorkflowByCompanyAndTypeAsync(Guid companyId, WorkflowType workflowType, CancellationToken cancellationToken)
        {
            return await _context.ApprovalWorkflows.AsNoTracking()
                .Include(w => w.Stages)
                .ThenInclude(s => s.Approvers)
                .FirstOrDefaultAsync(w => w.CompanyId == companyId && w.WorkflowType == workflowType, cancellationToken);
        }

        public async Task<IList<ApprovalWorkflow>> GetAllWorkflowsForCompanyAsync(Guid companyId, CancellationToken cancellationToken)
        {
            return await _context.ApprovalWorkflows.AsNoTracking()
                .Where(w => w.CompanyId == companyId)
                .Include(w => w.Stages)
                .ThenInclude(s => s.Approvers)
                .OrderBy(w => w.WorkflowType) // optional: order by enum
                .ToListAsync(cancellationToken);
        }
        public async Task<ApprovalWorkflowDto?> GetApprovalWorkflowByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.ApprovalWorkflows
                .AsNoTracking()
                .Include(w => w.Company)
                .Where(a => a.Id == id && !a.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<PaginatedResponse<ApprovalWorkflowDto>> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.ApprovalWorkflows
                .AsNoTracking()
                .Include(w => w.Company)
                .Where(q => !q.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    q.Company.CompanyName.ToLower().Contains(search) ||
                    q.WorkflowType.ToString().ToLower().Contains(search)
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
                query = query.OrderBy(a => a.Company.CompanyName); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<ApprovalWorkflowDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        public async Task<bool> IsWorkflowUniqueAsync(Guid companyId, WorkflowType workflowType, CancellationToken cancellationToken)
        {
            return !await _context.ApprovalWorkflows.AsNoTracking()
                .AnyAsync(x => x.CompanyId == companyId && x.WorkflowType == workflowType && !x.IsDeleted, cancellationToken);
        }
        public async Task<bool> IsWorkflowUniqueForUpdateAsync(Guid id, Guid companyId, WorkflowType workflowType, CancellationToken cancellationToken)
        {
            return !await _context.ApprovalWorkflows.AsNoTracking()
                .AnyAsync(x => x.CompanyId == companyId && x.WorkflowType == workflowType && x.Id != id && !x.IsDeleted, cancellationToken);
        }

        private ApprovalWorkflowDto MapToDto(Domain.Entity.Approval.ApprovalWorkflow response)
        {
            return new ApprovalWorkflowDto
            {
                Id = response.Id,
                CompanyId = response.CompanyId,
                CompanyName = response.Company.CompanyName,
                WorkflowType = response.WorkflowType,
                WorkflowTypeName = EnumHelper.FormatWorkflowType(response.WorkflowType),
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
       
    }
}
