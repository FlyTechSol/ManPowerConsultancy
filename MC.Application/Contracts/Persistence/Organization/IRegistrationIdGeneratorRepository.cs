using MC.Domain.Entity.Organization;

namespace MC.Application.Contracts.Persistence.Organization
{
    public interface IRegistrationIdGeneratorRepository : IGenericRepository<RegistrationSequence>
    {
        Task<string> GetNextRegistrationIdAsync(Guid companyId);
    }
}
