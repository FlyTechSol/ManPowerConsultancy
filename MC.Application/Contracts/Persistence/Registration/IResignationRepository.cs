using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IResignationRepository : IGenericRepository<Resignation>
    {
        Task<ResignationDetailDto?> GetByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<ResignationDetailDto?> GetByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<ResignationDetailDto?> GetResignationByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
