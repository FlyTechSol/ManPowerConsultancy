using MC.Application.Contracts.Persistence.Registration;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Registration
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<AddressDetailDto?> GetActiveAddressByUserIdAsync(int registrationId, CancellationToken cancellationToken)
        {
            var userProfileId = await _context.UserProfiles
                .AsNoTracking()
                .Where(up => up.RegistrationId == registrationId && !up.IsDeleted)
                .Select(up => up.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (userProfileId == Guid.Empty)
                return null;

            var address = await _context.Addresses
                .AsNoTracking()
                .Include(a => a.UserProfile)
                .Include(a => a.CreatedByUser!)
                    .ThenInclude(u => u.UserProfile)
                .Include(a => a.ModifiedByUser!)
                    .ThenInclude(u => u.UserProfile)
                .Where(addr => addr.UserProfileId == userProfileId && addr.IsActive)
                .Select(addr => new AddressDetailDto
                {
                    Id = addr.Id,
                    UserProfileId = addr.UserProfileId,
                    UserProfileName = addr.UserProfile.FirstName + " " + addr.UserProfile.LastName,
                    C_AddressLine1 = addr.C_AddressLine1,
                    C_AddressLine2 = addr.C_AddressLine2,
                    C_PinCode = addr.C_PinCode,
                    C_City = addr.C_City,
                    C_District = addr.C_District,
                    C_State = addr.C_State,
                    C_Country = addr.C_Country,
                    IsPermanentAddressSame = addr.IsPermanentAddressSame,
                    P_AddressLine1 = addr.P_AddressLine1,
                    P_AddressLine2 = addr.P_AddressLine2,
                    P_PinCode = addr.P_PinCode,
                    P_City = addr.P_City,
                    P_District = addr.P_District,
                    P_State = addr.P_State,
                    P_Country = addr.P_Country,
                    IsActive = addr.IsActive,
                    DateCreated = Helper.DateHelper.FormatDate(addr.DateCreated),
                    DateModified = Helper.DateHelper.FormatDate(addr.DateModified),
                    CreatedByName = Helper.UserHelper.GetFormattedName(addr.CreatedByUser),
                    ModifiedByName = Helper.UserHelper.GetFormattedName(addr.ModifiedByUser),

                })
                .FirstOrDefaultAsync(cancellationToken);

            return address;
        }

        public async Task<List<AddressDetailDto>?> GetInactiveAddressByUserIdAsync(int registrationId, CancellationToken cancellationToken)
        {
            // Step 1: Get UserProfileId from RegistrationId
            var userProfileId = await _context.UserProfiles
                .AsNoTracking()
                .Where(up => up.RegistrationId == registrationId && !up.IsDeleted)
                .Select(up => up.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (userProfileId == Guid.Empty)
                return null;

            // Step 2: Get all INACTIVE addresses for that user
            var addresses = await _context.Addresses
                .AsNoTracking()
                .Include(a => a.UserProfile)
                .Include(a => a.CreatedByUser!).ThenInclude(u => u.UserProfile)
                .Include(a => a.ModifiedByUser!).ThenInclude(u => u.UserProfile)
                .Where(addr => addr.UserProfileId == userProfileId && !addr.IsActive)
                .ToListAsync(cancellationToken);

            if (addresses == null)
                return null;

            var dtos = addresses.Select(addr => new AddressDetailDto
            {
                Id = addr.Id,
                UserProfileId = addr.UserProfileId,
                UserProfileName = $"{addr.UserProfile.FirstName} {addr.UserProfile.LastName}",
                C_AddressLine1 = addr.C_AddressLine1,
                C_AddressLine2 = addr.C_AddressLine2,
                C_PinCode = addr.C_PinCode,
                C_City = addr.C_City,
                C_District = addr.C_District,
                C_State = addr.C_State,
                C_Country = addr.C_Country,
                IsPermanentAddressSame = addr.IsPermanentAddressSame,
                P_AddressLine1 = addr.P_AddressLine1,
                P_AddressLine2 = addr.P_AddressLine2,
                P_PinCode = addr.P_PinCode,
                P_City = addr.P_City,
                P_District = addr.P_District,
                P_State = addr.P_State,
                P_Country = addr.P_Country,
                IsActive = addr.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(addr.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(addr.DateModified),
                CreatedByName = Helper.UserHelper.GetFormattedName(addr.CreatedByUser),
                ModifiedByName = Helper.UserHelper.GetFormattedName(addr.ModifiedByUser),
            }).ToList();

            return dtos;
        }

        public async Task<AddressDetailDto?> GetAddressByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var addr = await _context.Addresses
                .AsNoTracking()
                .Include(a => a.UserProfile)
                .Include(a => a.CreatedByUser!)
                    .ThenInclude(u => u.UserProfile)
                .Include(a => a.ModifiedByUser!)
                    .ThenInclude(u => u.UserProfile)
                .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted, cancellationToken);

            if (addr == null)
                return null;

            return new AddressDetailDto
            {
                Id = addr.Id,
                UserProfileId = addr.UserProfileId,
                UserProfileName = addr.UserProfile.FirstName + " " + addr.UserProfile.LastName,
                C_AddressLine1 = addr.C_AddressLine1,
                C_AddressLine2 = addr.C_AddressLine2,
                C_PinCode = addr.C_PinCode,
                C_City = addr.C_City,
                C_District = addr.C_District,
                C_State = addr.C_State,
                C_Country = addr.C_Country,
                IsPermanentAddressSame = addr.IsPermanentAddressSame,
                P_AddressLine1 = addr.P_AddressLine1,
                P_AddressLine2 = addr.P_AddressLine2,
                P_PinCode = addr.P_PinCode,
                P_City = addr.P_City,
                P_District = addr.P_District,
                P_State = addr.P_State,
                P_Country = addr.P_Country,
                IsActive = addr.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(addr.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(addr.DateModified),
                CreatedByName = Helper.UserHelper.GetFormattedName(addr.CreatedByUser),
                ModifiedByName = Helper.UserHelper.GetFormattedName(addr.ModifiedByUser),
            };
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
    }
}
