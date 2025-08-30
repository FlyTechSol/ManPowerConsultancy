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
    public class ZipCodeRepository : GenericRepository<ZipCode>, IZipCodeRepository
    {
        public ZipCodeRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<PaginatedResponse<ZipCodeDetailDto>?> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.ZipCodes
                .AsNoTracking()
                .Where(q => !q.IsDeleted);

          
            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    q.Zipcode.ToLower().Contains(search) ||
                    q.City.ToLower().Contains(search) ||
                    q.District.ToLower().Contains(search) ||
                    q.State.ToLower().Contains(search)
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
                query = query.OrderBy(a => a.Zipcode); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<ZipCodeDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }
        
        public async Task<ZipCodeDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.ZipCodes
                .AsNoTracking()
                .FirstOrDefaultAsync(lt => lt.Id == id && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;
            return MapToDto(response);
        }
        public async Task<ZipCodeDetailDto?> GetDetailsByZipCodeAsync(string zipCode, CancellationToken cancellationToken)
        {
            var response = await _context.ZipCodes
                .AsNoTracking()
                .FirstOrDefaultAsync(lt => lt.Zipcode == zipCode && !lt.IsDeleted, cancellationToken);

            if (response == null)
                return null;
            return MapToDto(response);
        }
        public async Task<bool> IsUnique(string zipCode, CancellationToken cancellationToken)
        {
            return !await _context.ZipCodes
               .AsNoTracking()
               .AnyAsync(q => q.Zipcode == zipCode && !q.IsDeleted, cancellationToken);
        }
        public async Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken)
        {
            return !await _context.ZipCodes
                .AsNoTracking()
                .AnyAsync(q => q.Zipcode == value
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }
        private ZipCodeDetailDto MapToDto(ZipCode response)
        {
            return new ZipCodeDetailDto
            {
                Id = response.Id,
                Zipcode = response.Zipcode,
                City = response.City,
                State = response.State,
                District = response.District,
                Country = response.Country,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
    }
}
