using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IEmployeeReferenceRepository : IGenericRepository<EmployeeReference>
    {
        Task<List<EmployeeReferenceDetailDto>?> GetAllEmpRefByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<List<EmployeeReferenceDetailDto>?> GetAllEmpRefByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<EmployeeReferenceDetailDto?> GetEmpRefByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<PaginatedResponse<EmployeeReferenceDetailDto>?> GetAllEmployeesByUserProfileIdAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken);
    }
}
