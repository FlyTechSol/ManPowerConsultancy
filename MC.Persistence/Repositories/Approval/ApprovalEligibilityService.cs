using MC.Application.Contracts.Identity;
using MC.Application.Contracts.Persistence.Approval;
using MC.Domain.Entity.Approval;
using MC.Persistence.Services;

namespace MC.Persistence.Repositories.Approval
{
    public class ApprovalEligibilityService : IApprovalEligibilityService
    {
        private readonly IIdentityService _identityService;

        public ApprovalEligibilityService(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<bool> CanUserApproveStageAsync(Guid userId, ApprovalStage stage)
        {
            if (stage.Approvers.Any(a => a.UserId == userId))
                return true;

            var roles = await _identityService.GetUserRolesAsync(userId);
            var companyId = await _identityService.GetUserCompanyIdAsync(userId);

            return stage.Approvers.Any(a =>
                a.RoleId.HasValue &&
                roles.Contains(a.RoleId.Value.ToString()) && // or map IDs
                (a.CompanyId == null || a.CompanyId == companyId));
        }
    }

}
