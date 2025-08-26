using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface ICommunicationRepository : IGenericRepository<Communication>
    {
        Task<CommunicationDetailDto?> GetByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken);
    }
}
