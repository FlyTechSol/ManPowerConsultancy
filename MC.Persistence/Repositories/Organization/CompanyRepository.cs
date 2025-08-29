using MC.Application.Contracts.Persistence.Organization;
using MC.Application.ModelDto.Organization;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Helper;
using Microsoft.EntityFrameworkCore;

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
                .AsNoTracking()
                .FirstOrDefaultAsync(g => !g.IsDeleted && g.Id == id, cancellationToken);

            if (response == null)
                return null;

            return MapToDto(response);
        }
        public async Task<List<CompanyDetailDto>> GetAllDetailsAsync(CancellationToken cancellationToken)
        {
            var response = await _context.Companies
               .AsNoTracking()
               .Where(q => !q.IsDeleted)
               .ToListAsync(cancellationToken);

            if (response == null || response.Count == 0)
                return new List<CompanyDetailDto>();

            var dtos = response.Select(MapToDto).ToList();
            return dtos;
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
                Email =response.Email,
                Phone = response.Phone,
                Website = response.Website,
                AddressLine1 = response.AddressLine1,
                AddressLine2 = response.AddressLine2,
                City = response.City,
                State = response.State,
                Country = response.Country,
                ZipCode = response.ZipCode,
                IsActive = response.IsActive,
                DateCreated = Helper.DateHelper.FormatDate(response.DateCreated),
                DateModified = Helper.DateHelper.FormatDate(response.DateModified),
                CreatedByName = response.CreatedByUserName ?? Defaults.Users.Unknown,
                ModifiedByName = response.ModifiedByUserName ?? Defaults.Users.Unknown,
            };
        }
    }
}
