using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Master
{
    public class CasteCategoryRepository : GenericRepository<Domain.Entity.Master.CasteCategory>, ICasteCategoryRepository
    {
        public CasteCategoryRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<List<CasteCategoryDto>> GetAllDetailsAsync(CancellationToken cancellationToken)
        {
            return await _context.CasteCategories
               .AsNoTracking()
               .Where(q => !q.IsDeleted)
               .Select(lt => new CasteCategoryDto
               {
                   Id = lt.Id,
                   DisplayOrder = lt.DisplayOrder,
                   Code = lt.Code,
                   Name = lt.Name,
               })
               .ToListAsync(cancellationToken);
        }

        public async Task<CasteCategoryDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.CasteCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(g => !g.IsDeleted && g.Id == id, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        public async Task<bool> IsUnique(string code, CancellationToken cancellationToken)
        {
            return !await _context.CasteCategories
                .AsNoTracking()
                .AnyAsync(q => q.Code == code && !q.IsDeleted, cancellationToken);
        }

        public async Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.CasteCategories
                .AsNoTracking()
                .AnyAsync(q => q.Code == value
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }
        private CasteCategoryDetailDto MapToDto(Domain.Entity.Master.CasteCategory response)
        {
            return new CasteCategoryDetailDto
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
