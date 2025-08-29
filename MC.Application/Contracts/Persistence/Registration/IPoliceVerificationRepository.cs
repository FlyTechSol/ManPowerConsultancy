using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IPoliceVerificationRepository : IGenericRepository<PoliceVerification>
    {
        Task<PoliceVerificationDetailDto?> GetPoliceVerificationByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<PoliceVerificationDetailDto?> GetPoliceVerificationByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<PoliceVerificationDetailDto?> GetPoliceVerificationByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
