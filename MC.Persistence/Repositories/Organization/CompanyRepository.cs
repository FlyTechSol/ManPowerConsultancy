using MC.Application.Contracts.Persistence.Organization;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Organization;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Organization
{
    public class CompanyRepository : GenericRepository<Domain.Entity.Organization.Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<CompanyDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.Companies
                .Include(q => q.RegistrationSequence)
                .AsNoTracking()
                .FirstOrDefaultAsync(g => !g.IsDeleted && g.Id == id, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<PaginatedResponse<CompanyDetailDto>?> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.Companies
               .Include(q => q.RegistrationSequence)
               .AsNoTracking()
               .Where(q => !q.IsDeleted);

            // Search filter
            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();
                query = query.Where(q =>
                    q.CompanyName.ToLower().Contains(search) ||
                    (q.LegalName != null && q.LegalName.ToLower().Contains(search)) ||
                    (q.RegistrationNumber != null && q.RegistrationNumber.ToLower().Contains(search))

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
                query = query.OrderBy(a => a.CompanyName); // default sort
            }

            // Pagination
            var data = await query
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            var dtos = data.Select(MapToDto).ToList();

            return new PaginatedResponse<CompanyDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }
        public async Task<bool> IsUnique(string companyName, CancellationToken cancellationToken)
        {
            return !await _context.Companies
                .AsNoTracking()
                .AnyAsync(q => q.CompanyName == companyName && !q.IsDeleted, cancellationToken);
        }
        public async Task<bool> IsUniqueForUpdate(Guid id, string companyName, CancellationToken cancellationToken)
        {
            return !await _context.Companies
                .AsNoTracking()
                .AnyAsync(q => q.CompanyName == companyName
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }
        private CompanyDetailDto MapToDto(Domain.Entity.Organization.Company response)
        {
            return new CompanyDetailDto
            {
                Id = response.Id,
                CompanyName = response.CompanyName,
                LegalName = response.LegalName,
                RegistrationNumber = response.RegistrationNumber,
                CompanyPan = response.CompanyPan,
                Email = response.Email,
                Phone = response.Phone,
                Website = response.Website,
                AddressLine1 = response.AddressLine1,
                AddressLine2 = response.AddressLine2,
                City = response.City,
                State = response.State,
                Country = response.Country,
                ZipCode = response.ZipCode,
                IsActive = response.IsActive,
                LastRegistrationId = response.RegistrationSequence.LastRegistrationId,
                RegistrationPrefix = response.RegistrationSequence.Prefix,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
    }
}
