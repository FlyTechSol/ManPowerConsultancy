using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using Microsoft.AspNetCore.Http;


namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IEmployeeVerificationRepository : IGenericRepository<EmployeeVerification>
    {
        Task<PaginatedResponse<EmployeeVerificationDetailDto>?> GetEmployeeVerificationByUserProfileIdAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken);
        Task<EmployeeVerificationDetailDto?> GetEmployeeVerificationByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateEmployeeVerificationAsync(EmployeeVerification request, IFormFile? agencyCertificateUrl, CancellationToken cancellationToken);
        Task<Guid> UpdateEmployeeVerificationAsync(EmployeeVerification request, IFormFile? agencyCertificateUrl, CancellationToken cancellationToken);
    }
}
