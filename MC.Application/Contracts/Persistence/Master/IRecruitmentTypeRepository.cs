using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;

namespace MC.Application.Contracts.Persistence.Master
{
    public interface IRecruitmentTypeRepository : IGenericRepository<Domain.Entity.Master.RecruitmentType>
    {
        Task<RecruitmentTypeDetailDto?> GetDetailsAsync(Guid id, CancellationToken cancellationToken);
        Task<PaginatedResponse<RecruitmentTypeDetailDto>?> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<bool> IsUnique(string code, CancellationToken cancellationToken);
        Task<bool> IsUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
    }
}
