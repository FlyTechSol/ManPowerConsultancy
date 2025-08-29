using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

namespace MC.Persistence.Repositories.Master
{
    public class CategoryRepository : GenericRepository<Domain.Entity.Master.Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDatabaseContext context) : base(context)
        {
        }

        public async Task<List<CategoryDetailDto>> GetAllDetailsAsync(CancellationToken cancellationToken)
        {
            var response =  await _context.Categories
               .AsNoTracking()
               .Where(q => !q.IsDeleted)
               .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<CategoryDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
        }

        public async Task<CategoryDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(g => !g.IsDeleted && g.Id == id, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        public async Task<bool> IsUnique(string code, CancellationToken cancellationToken)
        {
            return !await _context.Categories
                .AsNoTracking()
                .AnyAsync(q => q.Code == code && !q.IsDeleted, cancellationToken);
        }

        public async Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.Categories
                .AsNoTracking()
                .AnyAsync(q => q.Code == value
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }
        private CategoryDetailDto MapToDto(Domain.Entity.Master.Category response)
        {
            return new CategoryDetailDto
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
