using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IInsuranceNomineeRepository : IGenericRepository<InsuranceNominee>
    {
        Task<PaginatedResponse<InsuranceNomineeDetailDto>?> GetAllDetailsAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken);
        Task<List<InsuranceNomineeDetailDto>?> GetAllInsuranceNomineeByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<List<InsuranceNomineeDetailDto>?> GetAllInsuranceNomineeByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<InsuranceNomineeDetailDto?> GetInsuranceNomineeByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
