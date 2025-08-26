using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
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

        public async Task<SecurityDepositDetailDto?> GetSecurityDepositByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.SecurityDeposits
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .Where(ex => ex.UserProfileId == userProfile.Id && !ex.IsDeleted)
                .Select(ex => new SecurityDepositDetailDto
                {
                    Id = ex.Id,
                    UserProfileId = ex.UserProfileId,
                    UserProfileName = ex.UserProfile != null ? ex.UserProfile.FirstName + " " + ex.UserProfile.LastName : string.Empty,
                    ReciptNumber = ex.ReciptNumber,
                    Amount = ex.Amount,
                    RefundableAmount = ex.RefundableAmount,
                    NonRefundableAmount = ex.NonRefundableAmount,
                    ReceiptDate = ex.ReceiptDate,
                    Remark = ex.Remark,
                    IsActive = ex.IsActive,
                    DateCreated = Helper.DateHelper.FormatDate(ex.DateCreated),
                    DateModified = Helper.DateHelper.FormatDate(ex.DateModified),
                    CreatedByName = Helper.UserHelper.GetFormattedName(ex.CreatedByUser),
                    ModifiedByName = Helper.UserHelper.GetFormattedName(ex.ModifiedByUser),
                })
                .FirstOrDefaultAsync(cancellationToken);
            return response;
        }

        public async Task<SecurityDepositDetailDto?> GetSecurityDepositByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.SecurityDeposits
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            var dto = new SecurityDepositDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty,
                ReciptNumber = response.ReciptNumber,
                Amount = response.Amount,
                RefundableAmount = response.RefundableAmount,
                NonRefundableAmount = response.NonRefundableAmount,
                ReceiptDate = response.ReceiptDate,
                Remark = response.Remark,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = Helper.UserHelper.GetFormattedName(response.CreatedByUser),
                ModifiedByName = Helper.UserHelper.GetFormattedName(response.ModifiedByUser),
            };
            return dto;
        }
    }
}