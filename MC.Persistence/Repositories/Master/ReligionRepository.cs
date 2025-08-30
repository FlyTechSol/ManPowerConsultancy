using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Master
{
    public class ReligionRepository : GenericRepository<Domain.Entity.Master.Religion>, IReligionRepository
    {
        public ReligionRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<PaginatedResponse<ReligionDetailDto>?> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.Religions
                .AsNoTracking()
                .Where(q => !q.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    q.Code.ToLower().Contains(search) ||
                    q.Name.ToLower().Contains(search)
                );
            }

            // Total count before pagination
            var totalCount = await query.CountAsync(cancellationToken);

            // Sorting
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                string column = queryParams.Column;
                string direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "";

                query = query.OrderBy($"{column} {direction}");
            }
            else
            {
                query = query.OrderBy(a => a.DisplayOrder); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<ReligionDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }
        public async Task<ReligionDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Religions
                .AsNoTracking()
                .FirstOrDefaultAsync(g => !g.IsDeleted && g.Id == id, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        public async Task<bool> IsUnique(string code, CancellationToken cancellationToken)
        {
            return !await _context.Religions
                .AsNoTracking()
                .AnyAsync(q => q.Code == code && !q.IsDeleted, cancellationToken);
        }

        public async Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.Religions
                .AsNoTracking()
                .AnyAsync(q => q.Code == value
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }
        private ReligionDetailDto MapToDto(Domain.Entity.Master.Religion response)
        {
            return new ReligionDetailDto
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
