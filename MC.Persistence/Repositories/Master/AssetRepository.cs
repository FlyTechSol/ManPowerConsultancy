using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Master
{
    public class AssetRepository : GenericRepository<Domain.Entity.Master.Asset>, IAssetRepository
    {
        public AssetRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<List<AssetDto>> GetAllDetailsAsync(CancellationToken cancellationToken)
        {
            return await _context.Assets
               .AsNoTracking()
               .Where(q => !q.IsDeleted)
               .Select(lt => new AssetDto
               {
                   Id = lt.Id,
                   DisplayOrder = lt.DisplayOrder,
                   Code = lt.Code,
                   Name = lt.Name,
               })
               .ToListAsync(cancellationToken);
        }

        public async Task<AssetDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Assets
                .AsNoTracking()
                .Include(g => g.CreatedByUser)
                .Include(g => g.ModifiedByUser)
                .FirstOrDefaultAsync(g => !g.IsDeleted && g.Id == id, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        public async Task<bool> IsUnique(string code, CancellationToken cancellationToken)
        {
            return !await _context.Assets
                .AsNoTracking()
                .AnyAsync(q => q.Code == code && !q.IsDeleted, cancellationToken);
        }

        public async Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.Assets
                .AsNoTracking()
                .AnyAsync(q => q.Code == value
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }
        private AssetDetailDto MapToDto(Domain.Entity.Master.Asset response)
        {
            return new AssetDetailDto
            {
                Id = response.Id,
                DisplayOrder = response.DisplayOrder,
                Code = response.Code,
                Name = response.Name,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = Helper.UserHelper.GetFormattedName(response.CreatedByUser),
                ModifiedByName = Helper.UserHelper.GetFormattedName(response.ModifiedByUser),
            };
        }
    }
}
