using MC.Application.Model.Identity.Authorization;
using MC.Application.Model.Identity.Registration;

namespace MC.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(AuthRequest request, CancellationToken cancellationToken);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request, CancellationToken cancellationToken);
        Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken);
        Task<bool> IsUserNameUnique(string userName, CancellationToken cancellationToken);
    }
}
