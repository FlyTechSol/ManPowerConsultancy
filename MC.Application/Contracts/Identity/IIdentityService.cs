using MC.Application.Model.Identity.Authorization;
using MC.Domain.Entity.Identity;

namespace MC.Application.Contracts.Identity
{
    public interface IIdentityService
    {
        Task<ApplicationUser?> GetUserByIdAsync(Guid userId);
        Task<ApplicationUser?> GetUserByEmailAsync(string email);
        Task<bool> RegisterUserAsync(ApplicationUser user, string password);
        Task<bool> ConfirmEmailAsync(Guid userId, string token);
        Task<string?> GeneratePasswordResetTokenAsync(Guid userId);
        Task<bool> ResetPasswordAsync(Guid userId, string token, string newPassword);
        Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);
        Task<bool> LockUserAsync(Guid userId, TimeSpan? duration = null);
        Task<bool> UnlockUserAsync(Guid userId);
        Task<bool> UnlockUserByEmailAsync(string userEmail);
        Task<bool> IsUserLockedOutAsync(Guid userId);
        Task<TimeSpan?> GetLockoutRemainingTimeAsync(Guid userId);
        Task ResetAccessFailedCountAsync(Guid userId);
        Task<bool> DeleteUserAsync(Guid userId);
        Task<IList<string>> GetUserRolesAsync(Guid userId);
        Task<List<RoleDetails>> GetUserRoleDetailsAsync(Guid userId);
        Task<bool> AssignRoleAsync(Guid userId, string roleName);
        Task<bool> RemoveRoleAsync(Guid userId, string roleName);
    }
}
