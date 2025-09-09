using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Registration
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public AddressRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<PaginatedResponse<AddressDetailDto>?> GetAllDetailsAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.Addresses
                .AsNoTracking()
                .Where(addr => addr.UserProfileId == userProfileId && !addr.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    q.AddressLine1.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.AddressLine2) && q.AddressLine2.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.PinCode) && q.PinCode.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.City) && q.City.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.District) && q.District.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.State) && q.State.ToLower().Contains(search) ||
                    !string.IsNullOrWhiteSpace(q.Country) && q.Country.ToLower().Contains(search) 
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
                //query = query.OrderBy(a => a.IsActive); // default sort
                query = query.OrderByDescending(a => a.IsActive)
                             .ThenBy(a => a.AddressLine1); // optional secondary sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<AddressDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }

        public async Task<AddressDetailDto?> GetActiveAddressByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var address = await _context.Addresses
                .AsNoTracking()
                .Where(addr => addr.UserProfileId == userProfile.Id && addr.IsActive && !addr.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            return address == null ? null : MapToDto(address);
        }

        public async Task<List<AddressDetailDto>?> GetInactiveAddressByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetUserProfileByRegistrationIdAsync(registrationId, cancellationToken);

            if (userProfile == null)
                return null;

            var addresses = await _context.Addresses
                .AsNoTracking()
                .Where(addr => addr.UserProfileId == userProfile.Id && !addr.IsActive && !addr.IsDeleted)
                .ToListAsync(cancellationToken);

            if (addresses == null || addresses.Count == 0)
                return new List<AddressDetailDto>();

            var dtos = addresses.Select(MapToDto).ToList();
            return dtos;
        }

        public async Task<AddressDetailDto?> GetActiveAddressByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var address = await _context.Addresses
                .AsNoTracking()
                .Include(a => a.UserProfile)
                .Where(addr => addr.UserProfileId == userProfileId && addr.IsActive && !addr.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            return address == null ? null : MapToDto(address);
        }
        public async Task<List<AddressDetailDto>?> GetInactiveAddressByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            var addresses = await _context.Addresses
                .AsNoTracking()
                .Include(a => a.UserProfile)
                .Where(addr => addr.UserProfileId == userProfileId && !addr.IsActive && !addr.IsDeleted)
                .ToListAsync(cancellationToken);

            if (addresses == null || addresses.Count == 0)
                return new List<AddressDetailDto>();

            var dtos = addresses.Select(MapToDto).ToList();
            return dtos;
        }
        public async Task<AddressDetailDto?> GetAddressByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var addr = await _context.Addresses
                .AsNoTracking()
                .Include(a => a.UserProfile)
                .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted, cancellationToken);

            if (addr == null)
                return null;

            return MapToDto(addr);
        }

        public async Task UpdateRangeAsync(IEnumerable<Address> addresses, CancellationToken cancellationToken)
        {
            _context.Addresses.UpdateRange(addresses);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Address>> GetAllByUserIdAsync(Guid userProfileId, CancellationToken cancellationToken)
        {
            return await _context.Addresses
                .AsNoTracking()
                .Where(a => a.UserProfileId == userProfileId)
                .ToListAsync(cancellationToken);
        }

        private AddressDetailDto MapToDto(Domain.Entity.Registration.Address response)
        {
            return new AddressDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                //UserProfileName = response.UserProfile.FirstName + " " + response.UserProfile.LastName,
                AddressLine1 = response.AddressLine1,
                AddressLine2 = response.AddressLine2,
                PinCode = response.PinCode,
                City = response.City,
                District = response.District,
                State = response.State,
                Country = response.Country,
                AddressType = response.AddressType,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
    }
}
