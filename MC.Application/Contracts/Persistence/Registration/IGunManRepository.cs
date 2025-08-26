using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IGunManRepository : IGenericRepository<GunMan>
    {
        Task<GunManDetailDto?> GetAllGunMenByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken);
        Task<GunManDetailDto?> GetGunManByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}

