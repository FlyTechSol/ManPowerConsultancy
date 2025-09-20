using System.Linq.Dynamic.Core;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
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

        public async Task<PaginatedResponse<UserAssetDetailDto>?> GetAllUserAssetByUserProfileIdAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.UserAssets
                .AsNoTracking()
                .Include(ass => ass.Asset)
                .Where(ass => ass.UserProfileId == userProfileId && !ass.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    (q.SerialNo.ToLower().Contains(search)) ||
                    (q.Asset.Name.Contains(search)) 
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
                query = query.OrderBy(a => a.SerialNo); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<UserAssetDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        public async Task<List<UserAssetDetailDto>?> GetAllUserAssetByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var response = await _context.UserAssets
                .AsNoTracking()
                .Where(ex => ex.UserProfileId == userProfile.Id && !ex.IsDeleted)
                .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<UserAssetDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }
        //public async Task<List<UserAssetDetailDto>?> GetAllUserAssetByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        //{
        //    var response = await _context.UserAssets
        //        .AsNoTracking()
        //        .Where(ex => ex.UserProfileId == userProfileId && !ex.IsDeleted)
        //        .ToListAsync(cancellationToken);

        //    if (response == null || response.Count == 0)
        //        return new List<UserAssetDetailDto>();

        //    var dtos = response.Select(MapToDto).ToList();
        //    return dtos;
        //}
        public async Task<UserAssetDetailDto?> GetUserAssetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.UserAssets
                .AsNoTracking()
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        private UserAssetDetailDto MapToDto(Domain.Entity.Registration.UserAsset response)
        {
            return new UserAssetDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                //UserProfileName = response.UserProfile != null ? response.UserProfile.FirstName + " " + response.UserProfile.LastName : string.Empty,
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
                ReturnRemarks = response.ReturnRemarks,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown
            };
        }
    }
}
