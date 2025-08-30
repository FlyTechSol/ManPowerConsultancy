using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Master;

namespace MC.Application.Contracts.Persistence.Master
{
    public interface IZipCodeRepository : IGenericRepository<ZipCode>
    {
        Task<ZipCodeDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<ZipCodeDetailDto?> GetDetailsByZipCodeAsync(string zipCode, CancellationToken cancellationToken);
        Task<PaginatedResponse<ZipCodeDetailDto>?> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<bool> IsUnique(string zipCode, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
    }
}
