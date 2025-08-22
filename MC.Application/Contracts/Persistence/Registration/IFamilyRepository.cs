using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IFamilyRepository : IGenericRepository<Family>
    {
        Task<FamilyDetailDto?> GetAllFamilyByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<FamilyDetailDto?> GetFamilyByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
