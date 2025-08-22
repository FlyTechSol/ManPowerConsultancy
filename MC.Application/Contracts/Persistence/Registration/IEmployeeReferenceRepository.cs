using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IEmployeeReferenceRepository : IGenericRepository<EmployeeReference>
    {
        Task<EmployeeReferenceDetailDto?> GetAllEmpRefByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<EmployeeReferenceDetailDto?> GetEmpRefByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
