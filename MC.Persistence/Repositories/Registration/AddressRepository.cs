using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Master.Master;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public AddressRepository(IUserProfileRepository userProfileRepository, ApplicationDatabaseContext context) : base(context)
        {
            _userProfileRepository = userProfileRepository;
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
                .Where(a => a.UserProfileId == userProfileId)
                .ToListAsync(cancellationToken);
        }

        private AddressDetailDto MapToDto(Domain.Entity.Registration.Address response)
        {
            return new AddressDetailDto
            {
                Id = response.Id,
                UserProfileId = response.UserProfileId,
                UserProfileName = response.UserProfile.FirstName + " " + response.UserProfile.LastName,
                C_AddressLine1 = response.C_AddressLine1,
                C_AddressLine2 = response.C_AddressLine2,
                C_PinCode = response.C_PinCode,
                C_City = response.C_City,
                C_District = response.C_District,
                C_State = response.C_State,
                C_Country = response.C_Country,
                IsPermanentAddressSame = response.IsPermanentAddressSame,
                P_AddressLine1 = response.P_AddressLine1,
                P_AddressLine2 = response.P_AddressLine2,
                P_PinCode = response.P_PinCode,
                P_City = response.P_City,
                P_District = response.P_District,
                P_State = response.P_State,
                P_Country = response.P_Country,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
    }
}
