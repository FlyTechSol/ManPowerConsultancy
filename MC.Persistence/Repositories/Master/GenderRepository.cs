using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Master;
using MC.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Master
{
    public class GenderRepository : GenericRepository<Gender>, IGenderRepository
    {
        public GenderRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<List<GenderDto>> GetAllDetailsAsync(CancellationToken cancellationToken)
        {
            return await _context.Genders
                .AsNoTracking()
                .Where(q => !q.IsDeleted)
                .Select(lt => new GenderDto
                {
                    Id = lt.Id,
                    DisplayOrder = lt.DisplayOrder,
                    Code = lt.Code,
                    Name = lt.Name,
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<GenderDetailDto?> GetByCodeAsync(string code, CancellationToken cancellationToken)
        {
            var response = await _context.Genders
                .AsNoTracking()
                .Include(lt => lt.CreatedByUser)
                .Include(lt => lt.ModifiedByUser)
                .FirstOrDefaultAsync(lt => !lt.IsDeleted && lt.Code == code, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        public async Task<GenderDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Genders.AsNoTracking()
             .Include(g => g.CreatedByUser)
             .Include(g => g.ModifiedByUser)
             .FirstOrDefaultAsync(g => !g.IsDeleted && g.Id == id, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        public async Task<bool> IsUnique(string code, CancellationToken cancellationToken)
        {
            return !await _context.Genders
                .AsNoTracking()
                .AnyAsync(q => q.Code == code && !q.IsDeleted, cancellationToken);
        }

        public async Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.Genders
                .AsNoTracking()
                .AnyAsync(q => q.Code == value
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);

        }

        private GenderDetailDto MapToDto(Gender response)
        {
            return new GenderDetailDto
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
