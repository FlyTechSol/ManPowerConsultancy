using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IPoliceVerificationRepository : IGenericRepository<PoliceVerification>
    {
        Task<PoliceVerificationDetailDto?> GetPolicleVerificationByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken);
    }
}
