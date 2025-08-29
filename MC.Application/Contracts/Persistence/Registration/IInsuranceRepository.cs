using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IInsuranceRepository : IGenericRepository<Insurance>
    {
        Task<List<InsuranceDetailDto>?> GetInsuranceByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<List<InsuranceDetailDto>?> GetInsuranceByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<InsuranceDetailDto?> GetInsuranceByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
