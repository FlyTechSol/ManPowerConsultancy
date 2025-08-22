using MC.Application.ModelDto.Master.Master;
using MC.Domain.Entity.Master;

namespace MC.Application.Contracts.Persistence.Master
{
    public interface ITitleRepository : IGenericRepository<Title>
    {
        Task<TitleDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<List<TitleDto>> GetAllDetailsAsync(bool? isMale, CancellationToken cancellationToken);
        Task<bool> IsUnique(string code, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
    }
}
