using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IExArmyRepository : IGenericRepository<ExArmy>
    {
        Task<List<ExArmyDetailDto>?> GetAllExArmyByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<List<ExArmyDetailDto>?> GetAllExArmyByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<ExArmyDetailDto?> GetExArmyByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
