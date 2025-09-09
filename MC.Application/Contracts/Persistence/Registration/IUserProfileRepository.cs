using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Master.Master;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;
using Microsoft.AspNetCore.Http;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        Task<UserProfileDto?> GetUserProfileByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<UserProfileDto?> GetUserProfileByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<UserProfileShortDto?> GetUserProfileByApplicationUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<PaginatedResponse<UserProfileDto>> GetAllDetailsAsync(QueryParams queryParams, CancellationToken cancellationToken);
        Task<Guid> CreateUserProfileAsync(UserProfile request, Guid loggedInUserId, IFormFile? profilePicture, CancellationToken cancellationToken);
        Task<Guid> UpdateUserProfileAsync(UserProfile userProfile, IFormFile? profilePicture, CancellationToken cancellationToken);
        Task<bool> IsAadhaarUnique(string aadhaar, CancellationToken cancellationToken);
        Task<bool> IsPanUnique(string panCard, CancellationToken cancellationToken);
        Task<bool> IsUanNumberUnique(string aadhaar, CancellationToken cancellationToken);
        Task<bool> IsEsicUnique(string panCard, CancellationToken cancellationToken);
        Task<bool> IsAadhaarUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
        Task<bool> IsPanUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
        Task<bool> IsUanNumberUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
        Task<bool> IsEsicUniqueForUpdate(Guid id, string value, CancellationToken cancellationToken);
    }
}
