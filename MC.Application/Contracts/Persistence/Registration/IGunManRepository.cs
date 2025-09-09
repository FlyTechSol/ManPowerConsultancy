using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IGunManRepository : IGenericRepository<GunMan>
    {
        Task<PaginatedResponse<GunManDetailDto>?> GetAllDetailsAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken);
        Task<List<GunManDetailDto>?> GetAllGunMenByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<List<GunManDetailDto>?> GetAllGunMenByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<GunManDetailDto?> GetGunManByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}

