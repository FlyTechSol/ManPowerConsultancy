using MC.Application.Contracts.Identity;
using MC.Application.Exceptions;
using MC.Application.Model.Identity.Authorization;
using MC.Domain.Entity.Identity;
using MC.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ApplicationDatabaseContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public IdentityService(ApplicationDatabaseContext dbContext,
                               UserManager<ApplicationUser> userManager,
                               RoleManager<ApplicationRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(Guid userId)
            => await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

        public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
            => await _userManager.FindByEmailAsync(email);

        public async Task<bool> RegisterUserAsync(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        public async Task<bool> ConfirmEmailAsync(Guid userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result.Succeeded;
        }

        public async Task<string?> GeneratePasswordResetTokenAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user == null ? null : await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<bool> ResetPasswordAsync(Guid userId, string token, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }
        public async Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            return result.Succeeded;
        }

        public async Task<bool> LockUserAsync(Guid userId, TimeSpan? duration = null)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;
            user.LockoutEnd = duration.HasValue ? DateTimeOffset.UtcNow.Add(duration.Value) : DateTimeOffset.MaxValue;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> UnlockUserAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;
            user.LockoutEnd = DateTimeOffset.UtcNow;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> UnlockUserByEmailAsync(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null) return false;
            user.LockoutEnd = DateTimeOffset.UtcNow;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
        public async Task<bool> IsUserLockedOutAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;
            return await _userManager.IsLockedOutAsync(user);
        }
        public async Task ResetAccessFailedCountAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return;
            await _userManager.ResetAccessFailedCountAsync(user);
        }

        public async Task<TimeSpan?> GetLockoutRemainingTimeAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null || user.LockoutEnd == null) return null;
            var remaining = user.LockoutEnd.Value.UtcDateTime - DateTime.UtcNow;
            return remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero;
        }
        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<IList<string>> GetUserRolesAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user == null ? Array.Empty<string>() : await _userManager.GetRolesAsync(user);
        }
        public async Task<List<RoleDetails>> GetUserRoleDetailsAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new NotFoundException($"User with Id {userId} not found.", userId);

            var roleNames = await _userManager.GetRolesAsync(user);
            if (!roleNames.Any())
                throw new NotFoundException($"User with Id {userId} does not have any role.", userId);

            var roleDetails = new List<RoleDetails>();
            foreach (var roleName in roleNames)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    roleDetails.Add(new RoleDetails
                    {
                        RoleId = role.Id,
                        RoleName = role.Name ?? string.Empty
                    });
                }
            }

            return roleDetails;
        }

        public async Task<bool> AssignRoleAsync(Guid userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;
            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }

        public async Task<bool> RemoveRoleAsync(Guid userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;
            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            return result.Succeeded;
        }
    }
}
