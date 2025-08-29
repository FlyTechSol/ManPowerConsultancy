using MC.Application.Contracts.Persistence.Organization;
using MC.Application.ModelDto.Organization;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Organization
{
    public class UnitRepository : GenericRepository<Domain.Entity.Organization.ClientUnit>, IUnitRepository
    {
        public UnitRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<UnitDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.ClientUnits
                .AsNoTracking()
                .FirstOrDefaultAsync(g => !g.IsDeleted && g.Id == id, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<List<UnitDetailDto>> GetAllDetailsAsync(CancellationToken cancellationToken)
        {
            var response = await _context.ClientUnits
               .AsNoTracking()
               .Where(q => !q.IsDeleted)
               .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<UnitDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }
        public async Task<List<UnitDetailDto>> GetUnitByClientMasterIdAsync(Guid clientMasterId, CancellationToken cancellationToken)
        {
            var response = await _context.ClientUnits
               .AsNoTracking()
               .Where(q => !q.IsDeleted && q.ClientMasterId == clientMasterId)
               .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<UnitDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }
        public async Task<bool> IsUnique(Guid clientMasterId, string unitName, CancellationToken cancellationToken)
        {
            return !await _context.ClientUnits
                .AsNoTracking()
                .AnyAsync(q => q.ClientMasterId == clientMasterId && q.UnitName == unitName && !q.IsDeleted, cancellationToken);
        }

        public async Task<bool> IsUniqueForUpdate(Guid id, Guid clientMasterId, string unitName, CancellationToken cancellationToken)
        {
            return !await _context.ClientUnits
                .AsNoTracking()
                .AnyAsync(q => q.ClientMasterId == clientMasterId
                            && q.UnitName == unitName
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }
        private UnitDetailDto MapToDto(Domain.Entity.Organization.ClientUnit response)
        {
            return new UnitDetailDto
            {
                Id = response.Id,
                ClientMasterId = response.ClientMasterId,
                ClientMasterName = response.ClientMaster.ClientName,
                UnitName = response.UnitName,
                UnitLocation = response.UnitLocation,
                MaxHeadCount = response.MaxHeadCount,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
    }
}
