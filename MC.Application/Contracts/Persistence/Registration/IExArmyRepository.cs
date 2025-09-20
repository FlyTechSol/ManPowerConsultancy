using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using Microsoft.AspNetCore.Http;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IExArmyRepository : IGenericRepository<ExArmy>
    {
        Task<List<ExArmyDetailDto>?> GetAllExArmyByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<PaginatedResponse<ExArmyDetailDto>?> GetExArmyByUserProfileIdAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken);
        Task<ExArmyDetailDto?> GetExArmyByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateExArmyAsync(ExArmy request, IFormFile? dischargeCertificateUrl, CancellationToken cancellationToken);
        Task<Guid> UpdateExArmyAsync(ExArmy request, IFormFile? dischargeCertificateUrl, CancellationToken cancellationToken);
    }
}
