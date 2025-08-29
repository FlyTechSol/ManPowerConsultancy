using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IBodyMeasurementRepository : IGenericRepository<BodyMeasurement>
    {
        Task<BodyMeasurementDetailDto?> GetByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<BodyMeasurementDetailDto?> GetByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<BodyMeasurementDetailDto?> GetBodyMeasurementByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
