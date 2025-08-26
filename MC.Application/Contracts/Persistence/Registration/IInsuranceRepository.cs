using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IInsuranceRepository : IGenericRepository<Insurance>
    {
        Task<InsuranceDetailDto?> GetInsuranceByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken);
    }
}
