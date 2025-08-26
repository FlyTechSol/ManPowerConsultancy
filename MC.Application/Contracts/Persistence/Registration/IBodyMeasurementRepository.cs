using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IBodyMeasurementRepository : IGenericRepository<BodyMeasurement>
    {
        Task<BodyMeasurementDetailDto?> GetByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken);
    }
}
