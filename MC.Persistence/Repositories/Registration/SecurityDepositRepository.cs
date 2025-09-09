using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    internal class SecurityDepositRepository : GenericRepository<SecurityDeposit>, ISecurityDepositRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public SecurityDepositRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<SecurityDepositDetailDto?> GetSecurityDepositByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.SecurityDeposits
                .AsNoTracking()
                .Where(ex => ex.UserProfileId == userProfile.Id && !ex.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<SecurityDepositDetailDto?> GetSecurityDepositByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var response = await _context.SecurityDeposits
                .AsNoTracking()
                .Where(ex => ex.UserProfileId == userProfileId && !ex.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<SecurityDepositDetailDto?> GetSecurityDepositByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.SecurityDeposits
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        private SecurityDepositDetailDto MapToDto(Domain.Entity.Registration.SecurityDeposit response)
        {
            return new SecurityDepositDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                //UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty,
                ReciptNumber = response.ReciptNumber,
                Amount = response.Amount,
                RefundableAmount = response.RefundableAmount,
                NonRefundableAmount = response.NonRefundableAmount,
                ReceiptDate = response.ReceiptDate,
                Remark = response.Remark,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}