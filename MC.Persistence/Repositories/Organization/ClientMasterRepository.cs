using MC.Application.Contracts.Persistence.Organization;
using MC.Application.ModelDto.Organization;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Organization
{
    public class ClientMasterRepository : GenericRepository<Domain.Entity.Organization.ClientMaster>, IClientMasterRepository
    {
        public ClientMasterRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<ClientMasterDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.ClientMasters
                .AsNoTracking()
                .FirstOrDefaultAsync(g => !g.IsDeleted && g.Id == id, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<List<ClientMasterDetailDto>> GetAllDetailsAsync(CancellationToken cancellationToken)
        {
            var response = await _context.ClientMasters
               .AsNoTracking()
               .Where(q => !q.IsDeleted)
               .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<ClientMasterDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }
        public async Task<List<ClientMasterDetailDto>> GetClientMasterByCompanyIdAsync(Guid companyId, CancellationToken cancellationToken)
        {
            var response = await _context.ClientMasters
               .AsNoTracking()
               .Where(q => !q.IsDeleted && q.CompanyId == companyId)
               .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<ClientMasterDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }
        public async Task<bool> IsUnique(Guid companyId, string clientName, CancellationToken cancellationToken)
        {
            return !await _context.ClientMasters
                .AsNoTracking()
                .AnyAsync(q => q.ClientName == clientName && q.CompanyId == companyId && !q.IsDeleted, cancellationToken);
        }

        public async Task<bool> IsUniqueForUpdate(Guid id, Guid companyId, string clientName, CancellationToken cancellationToken)
        {
            return !await _context.ClientMasters
                .AsNoTracking()
                .AnyAsync(q => q.ClientName == clientName
                            && q.CompanyId == companyId
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }
        private ClientMasterDetailDto MapToDto(Domain.Entity.Organization.ClientMaster response)
        {
            return new ClientMasterDetailDto
            {
                Id = response.Id,
                CompanyId = response.CompanyId,
                CompanyName = response.Company.CompanyName,
                ClientName = response.ClientName,
                ProjectStartDate = response.ProjectStartDate,
                ProjectEndDate = response.ProjectEndDate,
                ProjectCost = response.ProjectCost,
                ProjectLocation = response.ProjectLocation,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
    }
}
