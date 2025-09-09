using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface ICommunicationRepository : IGenericRepository<Communication>
    {
        Task<CommunicationDetailDto?> GetByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<CommunicationDetailDto?> GetByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        //Task<PaginatedResponse<CommunicationDetailDto>?> GetCommunicationByUserProfileIdAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken);
        Task<CommunicationDetailDto?> GetCommunicationByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
