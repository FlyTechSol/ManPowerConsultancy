using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Organization;
using MC.Domain.Entity.Organization;

namespace MC.Application.Contracts.Persistence.Organization
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<CompanyDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<PaginatedResponse<CompanyDetailDto>?> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<bool> IsUnique(string companyName, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string companyName, CancellationToken cancellationToken);
    }
}
