using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IInsuranceNomineeRepository : IGenericRepository<InsuranceNominee>
    {
        Task<InsuranceNomineeDetailDto?> GetAllInsuranceNomineeByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<InsuranceNomineeDetailDto?> GetInsuranceNomineeByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
