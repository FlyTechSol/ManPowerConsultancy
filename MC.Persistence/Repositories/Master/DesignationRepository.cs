using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Master
{
    public class DesignationRepository : GenericRepository<Domain.Entity.Master.Designation>, IDesignationRepository
    {
        public DesignationRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<List<DesignationDetailDto>> GetAllDetailsAsync(CancellationToken cancellationToken)
        {
            var response = await _context.Designations
               .AsNoTracking()
               .Where(q => !q.IsDeleted)
               .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<DesignationDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }

        public async Task<DesignationDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Designations
                .AsNoTracking()
                .FirstOrDefaultAsync(g => !g.IsDeleted && g.Id == id, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        public async Task<bool> IsUnique(string code, CancellationToken cancellationToken)
        {
            return !await _context.Designations
                .AsNoTracking()
                .AnyAsync(q => q.Code == code && !q.IsDeleted, cancellationToken);
        }

        public async Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.Designations
                .AsNoTracking()
                .AnyAsync(q => q.Code == value
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }
        private DesignationDetailDto MapToDto(Domain.Entity.Master.Designation response)
        {
            return new DesignationDetailDto
            {
                Id = response.Id,
                DisplayOrder = response.DisplayOrder,
                Code = response.Code,
                Name = response.Name,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
    }
}
