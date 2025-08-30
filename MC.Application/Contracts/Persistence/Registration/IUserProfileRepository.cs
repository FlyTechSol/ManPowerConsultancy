using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        Task<UserProfileDto?> GetUserProfileByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<UserProfileDto?> GetUserProfileByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<UserProfileShortDto?> GetUserProfileByApplicationUserIdAsync(Guid userId, CancellationToken cancellationToken);
        //Task<Guid> CreateUserProfileAsync(UserProfileDto request);
        Task<bool> IsAadhaarUnique(string aadhaar);
        Task<bool> IsPanUnique(string panCard);
        Task<bool> IsUanNumberUnique(string aadhaar);
        Task<bool> IsEsicUnique(string panCard);
        Task<bool> IsAadhaarUniqueForUpdate(Guid id, string value);
        Task<bool> IsPanUniqueForUpdate(Guid id, string value);
        Task<bool> IsUanNumberUniqueForUpdate(Guid id, string value);
        Task<bool> IsEsicUniqueForUpdate(Guid id, string value);
    }
}
