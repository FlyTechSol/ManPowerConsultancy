
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class UserAssetRepository : GenericRepository<UserAsset>, IUserAssetRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UserAssetRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<UserAssetDetailDto?> GetAllUserAssetByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.UserAssets
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .Where(ex => ex.UserProfileId == userProfile.Id && !ex.IsDeleted)
                .Select(ex => new UserAssetDetailDto
                {
                    Id = ex.Id,
                    UserProfileId = ex.UserProfileId,
                    UserProfileName = ex.UserProfile != null ? ex.UserProfile.FirstName + " " + ex.UserProfile.LastName : string.Empty,
                    AssetId = ex.AssetId,
                    AssetName = ex.Asset != null ? ex.Asset.Name : string.Empty,
                    DateOfIssue = ex.DateOfIssue,
                    SerialNo = ex.SerialNo,
                    AssetValue = ex.AssetValue,
                    Quantity = ex.Quantity,
                    Remarks = ex.Remarks,
                    IsReturnable = ex.IsReturnable,
                    IsReturned = ex.IsReturned,
                    ReturnDate = ex.ReturnDate,
                    ReturnStatus = ex.ReturnStatus,
                    IsActive = ex.IsActive,
                    DateCreated = Helper.DateHelper.FormatDate(ex.DateCreated),
                    DateModified = Helper.DateHelper.FormatDate(ex.DateModified),
                    CreatedByName = Helper.UserHelper.GetFormattedName(ex.CreatedByUser),
                    ModifiedByName = Helper.UserHelper.GetFormattedName(ex.ModifiedByUser),
                })
                .FirstOrDefaultAsync(cancellationToken);
            return response;
        }

        public async Task<UserAssetDetailDto?> GetUserAssetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.UserAssets
                .AsNoTracking()
                .Include(ex => ex.UserProfile)
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            var dto = new UserAssetDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty,
                AssetId = response.AssetId,
                AssetName = response.Asset != null ? response.Asset.Name : string.Empty,
                DateOfIssue = response.DateOfIssue,
                SerialNo = response.SerialNo,
                AssetValue = response.AssetValue,
                Quantity = response.Quantity,
                Remarks = response.Remarks,
                IsReturnable = response.IsReturnable,
                IsReturned = response.IsReturned,
                ReturnDate = response.ReturnDate,
                ReturnStatus = response.ReturnStatus, // e.g., "Good", "Fair", "Bad"
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
