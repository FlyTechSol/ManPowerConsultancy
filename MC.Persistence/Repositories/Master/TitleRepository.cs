using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Master;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Master
{
    public class TitleRepository : GenericRepository<Title>, ITitleRepository
    {
        public TitleRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<PaginatedResponse<TitleDetailDto>?> GetAllDetailsAsync(QueryParams queryParams, bool? isMale, CancellationToken cancellationToken)
        {
            var query = _context.Titles
                .AsNoTracking()
                .Where(q => !q.IsDeleted);

            if (isMale.HasValue && isMale == true)
                query = query.Where(t => t.IsMale == true);

            else if (isMale.HasValue && isMale == false || isMale == null)
                query = query.Where(t => t.IsFemale == true);

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

            return new PaginatedResponse<TitleDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }
        
        public async Task<TitleDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Titles
                .AsNoTracking()
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            return response == null ? null : MapToDto(response);
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

        private TitleDetailDto MapToDto(Domain.Entity.Master.Title response)
        {
            return new TitleDetailDto
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
        }
    }
}
