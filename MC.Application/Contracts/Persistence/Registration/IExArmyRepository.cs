using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IExArmyRepository : IGenericRepository<ExArmy>
    {
        Task<ExArmyDetailDto?> GetAllExArmyByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken);
        Task<ExArmyDetailDto?> GetExArmyByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
