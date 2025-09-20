using MC.Application.Contracts.Persistence.Approval;
using MC.Application.ModelDto.Approval;
using MC.Application.ModelDto.Common.Pagination;
using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;
using MC.Domain.Entity.Identity;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Approval
{
    public class ApprovalRequestStageRepository : GenericRepository<ApprovalRequestStage>, IApprovalRequestStageRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public ApprovalRequestStageRepository(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ApplicationDatabaseContext context) : base(context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AddApprovalRequestStagesAsync(
                ApprovalRequest approvalRequest,
                IEnumerable<ApprovalStage> stages,
                CancellationToken cancellationToken)
        {
            var orderedStages = stages.OrderBy(s => s.Order).ToList();

            var requestStages = orderedStages.Select((stage, index) => new ApprovalRequestStage
            {
                Id = Guid.NewGuid(),
                ApprovalRequestId = approvalRequest.Id,
                ApprovalStageId = stage.Id,
                // first stage active, others waiting
                Status = index == 0 ? StageStatus.Pending : StageStatus.NotStarted,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            });

            _context.ApprovalRequestStages.AddRange(requestStages);
            await _context.SaveChangesAsync(cancellationToken);
        }


        //public async Task AddApprovalRequestStagesAsync(ApprovalRequest approvalRequest, IEnumerable<ApprovalStage> stages, CancellationToken cancellationToken)
        //{
        //    var requestStages = stages.Select(s => new ApprovalRequestStage
        //    {
        //        Id = Guid.NewGuid(),
        //        ApprovalRequestId = approvalRequest.Id,
        //        ApprovalStageId = s.Id,
        //        Status = StageStatus.Pending,
        //        DateCreated = DateTime.UtcNow,
        //        DateModified = DateTime.UtcNow
        //    });

        //    _context.ApprovalRequestStages.AddRange(requestStages);
        //    await _context.SaveChangesAsync(cancellationToken);
        //}
        public async Task<IList<ApprovalRequestStage>> GetStagesByRequestIdAsync(Guid approvalRequestId, CancellationToken cancellationToken)
        {
            return await _context.ApprovalRequestStages
                .Where(s => s.ApprovalRequestId == approvalRequestId)
                .Include(s => s.Stage)
                    .ThenInclude(st => st.Approvers)
                .Include(s => s.Actions)
                .Where(s => !s.IsDeleted)
                .OrderBy(s => s.Stage.Order)
                .ToListAsync(cancellationToken);
        }

        public async Task<ApprovalRequestStage?> GetCurrentStageAsync(Guid approvalRequestId, CancellationToken cancellationToken)
        {
            return await _context.ApprovalRequestStages
                .Where(s => s.ApprovalRequestId == approvalRequestId && s.Status == StageStatus.Pending)
                .Include(s => s.Stage)
                    .ThenInclude(st => st.Approvers)
                .Include(s => s.Actions)
                .Where(s => !s.IsDeleted)
                .OrderBy(s => s.Stage.Order)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task UpdateStageStatusAsync(Guid approvalRequestStageId, StageStatus status, CancellationToken cancellationToken)
        {
            var stage = await _context.ApprovalRequestStages.FindAsync(approvalRequestStageId);
            if (stage != null)
            {
                stage.Status = status;
                stage.DateModified = DateTime.UtcNow;
                _context.Update(stage);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        //public async Task<IList<ApprovalRequestStage>> GetPendingStagesForApproverAsync(Guid approverId, CancellationToken cancellationToken)
        //{
        //    var query = _context.ApprovalRequestStages
        //        .AsNoTracking()
        //        .Include(s => s.Request)
        //        .Include(rs => rs.Stage)
        //            .ThenInclude(s => s.Workflow)
        //        .Include(rs => rs.Request)
        //            .ThenInclude(r => r.RequestedUser)
        //        .Where(rs => !rs.IsDeleted &&
        //                (rs.Status == StageStatus.Pending || rs.Status == StageStatus.InProgress))
        //        .Where(rs =>
        //            rs.Stage.Approvers.Any(a => a.UserId == approverId) ||
        //            rs.Stage.Approvers.Any(a =>
        //                a.DesignationId != null &&
        //                a.Designation != null &&
        //                a.Designation.UserProfiles.Any(up => up.UserId == approverId)
        //            )
        //        );

        //    return await query.ToListAsync(cancellationToken);
        //}
        public async Task<IList<ApprovalRequestStage>> GetPendingStagesForApproverAsync(Guid approverId, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users
               .Include(u => u.UserProfile)
               .FirstOrDefaultAsync(u => u.Id == approverId, cancellationToken);

            if (user == null)
                throw new UnauthorizedAccessException("User not found.");


            var roleNames = await _userManager.GetRolesAsync(user);

            var roles = await _roleManager.Roles
                .Where(r => r.Name != null && roleNames.Contains(r.Name))
                .ToListAsync(cancellationToken);

            // r.Id is Guid here:
            var roleGuids = roles.Select(r => r.Id).ToList();  // no Parse

            var userCompanyId = user.UserProfile?.CompanyId;

            var query = _context.ApprovalRequestStages
                .AsNoTracking()
                .Include(rs => rs.Request)
                    .ThenInclude(r => r.RequestedUser)
                .Include(rs => rs.Stage)
                    .ThenInclude(s => s.Workflow)
                .Include(rs => rs.Stage)
                    .ThenInclude(s => s.Approvers)
                .Where(rs => !rs.IsDeleted &&
                             (rs.Status == StageStatus.Pending || rs.Status == StageStatus.InProgress))
                .Where(rs =>
                    // Direct assignment
                    rs.Stage.Approvers.Any(a => a.UserId == approverId)
                    ||
                    // Role assignment anywhere
                    rs.Stage.Approvers.Any(a =>
                        a.RoleId.HasValue &&
                        roleGuids.Contains(a.RoleId.Value) &&
                        (
                            // If CompanyId is NULL → visible to all users with this role
                            a.CompanyId == null
                            // If CompanyId set → only visible if same company
                            || (userCompanyId.HasValue && a.CompanyId == userCompanyId)
                        )
                    )
                );
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<PaginatedResponse<ApprovalRequestStageDto>> GetPendingStagesForApproverAsync(Guid approverId, QueryParams queryParams, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users
             .Include(u => u.UserProfile)
             .FirstOrDefaultAsync(u => u.Id == approverId, cancellationToken);

            if (user == null)
                throw new UnauthorizedAccessException("User not found.");

            var userRoleIds = await _userManager.GetRolesAsync(user);
            var roleGuids = userRoleIds.Select(r => Guid.Parse(r)).ToList(); // assuming your roles are GUIDs
            var userCompanyId = user.UserProfile?.CompanyId;

            // 2️⃣ Get pending stages
            var query = _context.ApprovalRequestStages
                .AsNoTracking()
                .Include(s => s.Request)
                .Include(rs => rs.Stage)
                    .ThenInclude(s => s.Approvers)
                .Where(rs => !rs.IsDeleted &&
                             (rs.Status == StageStatus.Pending || rs.Status == StageStatus.InProgress))
                .Where(rs =>
                    // Direct user
                    rs.Stage.Approvers.Any(a => a.UserId == approverId) ||

                    // Role anywhere (CompanyId null)
                    rs.Stage.Approvers.Any(a =>
                        a.RoleId.HasValue &&
                        roleGuids.Contains(a.RoleId.Value) &&
                        a.CompanyId == null
                    ) ||

                    // Role in user's company
                    rs.Stage.Approvers.Any(a =>
                        a.RoleId.HasValue &&
                        roleGuids.Contains(a.RoleId.Value) &&
                        a.CompanyId.HasValue &&
                        userCompanyId.HasValue &&
                        a.CompanyId == userCompanyId
                    )
                );

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    q.Status.ToString().ToLower().Contains(search)
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

            return new PaginatedResponse<ApprovalRequestStageDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        public async Task<IList<ApprovalRequestStage>> GetPreviousStagesAsync(Guid approvalRequestId, int currentOrder, CancellationToken cancellationToken)
        {
            return await _context.ApprovalRequestStages
                .Include(s => s.Stage)
                .Where(s => s.ApprovalRequestId == approvalRequestId && s.Stage.Order < currentOrder && !s.IsDeleted)
                .OrderBy(s => s.Stage.Order)
                .ToListAsync(cancellationToken);
        }
        public async Task<ApprovalRequestStage?> GetNextStageAsync(Guid approvalRequestId, int currentOrder, CancellationToken cancellationToken)
        {
            return await _context.ApprovalRequestStages
                .Include(s => s.Stage)
                .Where(s => s.ApprovalRequestId == approvalRequestId &&
                            s.Stage.Order == currentOrder + 1)
                .FirstOrDefaultAsync(cancellationToken);
        }
        private ApprovalRequestStageDto MapToDto(Domain.Entity.Approval.ApprovalRequestStage response)
        {
            return new ApprovalRequestStageDto
            {
                Id = response.Id,
                ApprovalRequestId = response.ApprovalRequestId,
                ApprovalRequestName = response.Request.RequestType.ToString(),
                ApprovalStageId = response.ApprovalStageId,
                ApprovalStageName = response.Stage.ApprovalMode.ToString(),
                Status = response.Status,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
    }

}
