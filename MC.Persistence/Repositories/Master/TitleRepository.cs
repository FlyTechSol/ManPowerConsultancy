using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Master;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Master
{
    public class TitleRepository : GenericRepository<Title>, ITitleRepository
    {
        public TitleRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<List<TitleDto>> GetAllDetailsAsync(bool? isMale, CancellationToken cancellationToken)
        {
            var query = _context.Titles
                .AsNoTracking()
                .Where(t => t.IsDeleted == false);

            if (isMale.HasValue && isMale == true)
                query = query.Where(t => t.IsMale == true);

            else if (isMale.HasValue && isMale == false)
                query = query.Where(t => t.IsFemale == true);

            return await query
                .Select(lt => new TitleDto
                {
                    Id = lt.Id,
                    DisplayOrder = lt.DisplayOrder,
                    Code = lt.Code,
                    Name = lt.Name,
                    IsFemale = lt.IsFemale,
                    IsMale = lt.IsMale
                })
                .ToListAsync(cancellationToken);
        }
        public async Task<TitleDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Titles
                .AsNoTracking()
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            var dto = new TitleDetailDto
            {
                Id = response.Id,
                DisplayOrder = response.DisplayOrder,
                Code = response.Code,
                Name = response.Name,
                IsFemale = response.IsFemale,
                IsMale = response.IsMale,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
            return dto;
        }
        public async Task<bool> IsUnique(string code, CancellationToken cancellationToken)
        {
            return !await _context.Titles
                .AsNoTracking()
                .AnyAsync(q => q.Code == code && !q.IsDeleted, cancellationToken);
        }
        public async Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.Titles
                .AsNoTracking()
                .AnyAsync(q => q.Code == value
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }
    }
}
