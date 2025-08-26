using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IUserGeneralDetailRepository : IGenericRepository<UserGeneralDetail>
    {
        Task<UserGeneralDetailDto?> GetUserGeneralByRegistrationIdAsync(int registrationId, CancellationToken cancellationToken);
    }
}
