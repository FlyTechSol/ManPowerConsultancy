using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IPreviousExperienceRepository : IGenericRepository<PreviousExperience>
    {
        Task<PaginatedResponse<PreviousExperienceDetailDto>?> GetAllDetailsAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken);
        Task<List<PreviousExperienceDetailDto>?> GetAllPreviousExperienceByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<List<PreviousExperienceDetailDto>?> GetAllPreviousExperienceByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<PreviousExperienceDetailDto?> GetPreviousExperienceByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
