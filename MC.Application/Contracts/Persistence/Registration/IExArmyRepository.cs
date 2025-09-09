using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IExArmyRepository : IGenericRepository<ExArmy>
    {
        Task<List<ExArmyDetailDto>?> GetAllExArmyByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<PaginatedResponse<ExArmyDetailDto>?> GetExArmyByUserProfileIdAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken);
        Task<ExArmyDetailDto?> GetExArmyByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
