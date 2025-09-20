using MC.Application.Contracts.Persistence.Organization;
using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Organization;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace MC.Persistence.Repositories.Organization
{
    public class ClientMasterRepository : GenericRepository<Domain.Entity.Organization.ClientMaster>, IClientMasterRepository
    {
        public ClientMasterRepository(ApplicationDatabaseContext context) : base(context)
        {
        }
        public async Task<ClientMasterDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var response = await _context.ClientMasters
                .AsNoTracking()
                .Include(g => g.Company)
                .FirstOrDefaultAsync(g => !g.IsDeleted && g.Id == id && !g.Company.IsDeleted, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }

        public async Task<PaginatedResponse<ClientMasterDetailDto>?> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken)
        {
            var query = _context.ClientMasters
                .AsNoTracking()
                .Where(q => !q.IsDeleted && !q.Company.IsDeleted);

            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();  // Consider case-insensitive search optimization

                if (Guid.TryParse(search, out Guid companyId))
                {
                    // Search by ClientMasterId, UnitName, or UnitLocation
                    query = query.Where(q =>
                        q.CompanyId == companyId ||
                        q.ClientName.Contains(search) ||
                        q.ProjectLocation.Contains(search)
                    );
                }
                else
                {
                    // Search only by UnitName or UnitLocation if it's not a valid GUID
                    query = query.Where(q =>
                        q.ClientName.Contains(search) ||
                        q.ProjectLocation.Contains(search)
                    );
                }
            }

            // Use projection to directly fetch only needed fields
            var dataQuery = query
                .Include(q => q.Company)  // Eagerly load company to avoid lazy loading
                .Select(q => new
                {
                    q.Id,
                    q.CompanyId,
                    CompanyName = q.Company != null ? q.Company.CompanyName : null,
                    q.ClientName,
                    q.ProjectStartDate,
                    q.ProjectEndDate,
                    q.ProjectCost,
                    q.ProjectLocation,
                    q.IsActive,
                    q.DateCreated,
                    q.DateModified,
                    q.CreatedByUserName,
                    q.ModifiedByUserName
                });

            // Total count before pagination
            var totalCount = await dataQuery.CountAsync(cancellationToken);

            // Sorting with dynamic ordering (ensure this doesn't impact performance too much)
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                string column = queryParams.Column;
                string direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "ascending";
                // Apply dynamic sorting (ensure column is valid to avoid runtime issues)
                dataQuery = dataQuery.OrderBy($"{column} {direction}");
            }
            else
            {
                dataQuery = dataQuery.OrderBy(a => a.ClientName); // Default sort by UnitName
            }

            // Pagination
            var data = await dataQuery
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            // Map the data to DTOs
            var dtos = data.Select(d => new ClientMasterDetailDto
            {
                Id = d.Id,
                CompanyId = d.CompanyId,
                CompanyName = d.CompanyName ?? string.Empty,
                ClientName = d.ClientName,
                ProjectStartDate = d.ProjectStartDate,
                ProjectEndDate = d.ProjectEndDate,
                ProjectCost = d.ProjectCost,
                ProjectLocation = d.ProjectLocation,
                IsActive = d.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(d.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(d.DateModified),
                CreatedByName = d.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = d.ModifiedByUserName ?? Defaults.Users.Unknown,
            }).ToList();

            // Return paginated response
            return new PaginatedResponse<ClientMasterDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }


        public async Task<PaginatedResponse<ClientMasterDetailDto>?> GetClientMasterByCompanyIdAsync(QueryParams queryParams, Guid companyId, CancellationToken cancellationToken)
        {
            var query = _context.ClientMasters
               .AsNoTracking()
               .Where(q => !q.IsDeleted && q.CompanyId == companyId && !q.Company.IsDeleted);

            if (!string.IsNullOrWhiteSpace(queryParams.Query))
            {
                var search = queryParams.Query.ToLower();  // Consider case-insensitive search optimization

                if (Guid.TryParse(search, out Guid companyFilterId))
                {
                    // Search by ClientMasterId, UnitName, or UnitLocation
                    query = query.Where(q =>
                        q.CompanyId == companyFilterId ||
                        q.ClientName.Contains(search) ||
                        q.ProjectLocation.Contains(search)
                    );
                }
                else
                {
                    // Search only by UnitName or UnitLocation if it's not a valid GUID
                    query = query.Where(q =>
                        q.ClientName.Contains(search) ||
                        q.ProjectLocation.Contains(search)
                    );
                }
            }

            // Use projection to directly fetch only needed fields
            var dataQuery = query
                .Include(q => q.Company)  // Eagerly load company to avoid lazy loading
                .Select(q => new
                {
                    q.Id,
                    q.CompanyId,
                    CompanyName = q.Company != null ? q.Company.CompanyName : null,
                    q.ClientName,
                    q.ProjectStartDate,
                    q.ProjectEndDate,
                    q.ProjectCost,
                    q.ProjectLocation,
                    q.IsActive,
                    q.DateCreated,
                    q.DateModified,
                    q.CreatedByUserName,
                    q.ModifiedByUserName
                });

            // Total count before pagination
            var totalCount = await dataQuery.CountAsync(cancellationToken);

            // Sorting with dynamic ordering (ensure this doesn't impact performance too much)
            if (!string.IsNullOrWhiteSpace(queryParams.Column))
            {
                string column = queryParams.Column;
                string direction = queryParams.Dir?.ToLower() == "desc" ? "descending" : "ascending";
                // Apply dynamic sorting (ensure column is valid to avoid runtime issues)
                dataQuery = dataQuery.OrderBy($"{column} {direction}");
            }
            else
            {
                dataQuery = dataQuery.OrderBy(a => a.ClientName); // Default sort by UnitName
            }

            // Pagination
            var data = await dataQuery
                .Skip((queryParams.Page - 1) * queryParams.Limit)
                .Take(queryParams.Limit)
                .ToListAsync(cancellationToken);

            // Map the data to DTOs
            var dtos = data.Select(d => new ClientMasterDetailDto
            {
                Id = d.Id,
                CompanyId = d.CompanyId,
                CompanyName = d.CompanyName ?? string.Empty,
                ClientName = d.ClientName,
                ProjectStartDate = d.ProjectStartDate,
                ProjectEndDate = d.ProjectEndDate,
                ProjectCost = d.ProjectCost,
                ProjectLocation = d.ProjectLocation,
                IsActive = d.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(d.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(d.DateModified),
                CreatedByName = d.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = d.ModifiedByUserName ?? Defaults.Users.Unknown,
            }).ToList();

            // Return paginated response
            return new PaginatedResponse<ClientMasterDetailDto>
            {
                Data = dtos,
                CurrentPage = queryParams.Page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.Limit)
            };
        }
        public async Task<bool> IsUnique(Guid companyId, string clientName, CancellationToken cancellationToken)
        {
            return !await _context.ClientMasters
                .AsNoTracking()
                .AnyAsync(q => q.ClientName == clientName && q.CompanyId == companyId && !q.IsDeleted, cancellationToken);
        }

        public async Task<bool> IsUniqueForUpdate(Guid id, Guid companyId, string clientName, CancellationToken cancellationToken)
        {
            return !await _context.ClientMasters
                .AsNoTracking()
                .AnyAsync(q => q.ClientName == clientName
                            && q.CompanyId == companyId
                            && q.Id != id
                            && !q.IsDeleted, cancellationToken);
        }
        private ClientMasterDetailDto MapToDto(Domain.Entity.Organization.ClientMaster response)
        {
            return new ClientMasterDetailDto
            {
                Id = response.Id,
                CompanyId = response.CompanyId,
                CompanyName = response.Company.CompanyName,
                ClientName = response.ClientName,
                ProjectStartDate = response.ProjectStartDate,
                ProjectEndDate = response.ProjectEndDate,
                ProjectCost = response.ProjectCost,
                ProjectLocation = response.ProjectLocation,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
    }
}
