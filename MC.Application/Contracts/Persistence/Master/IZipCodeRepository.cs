using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Master;

namespace MC.Application.Contracts.Persistence.Master
{
    public interface IZipCodeRepository : IGenericRepository<ZipCode>
    {
        Task<ZipCodeDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<ZipCodeDetailDto?> GetDetailsByZipCodeAsync(string zipCode, CancellationToken cancellationToken);
        Task<List<ZipCodeDto>> GetAllDetailsAsync(CancellationToken cancellationToken);
        Task<bool> IsUnique(string zipCode, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
    }
}
