using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IResignationRepository : IGenericRepository<Resignation>
    {
        Task<ResignationDetailDto?> GetByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken);
    }
}
