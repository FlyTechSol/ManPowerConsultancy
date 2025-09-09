using MC.Application.Contracts.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace MC.Infrastructure.Identity
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId
        {
            get
            {
                var user = _httpContextAccessor.HttpContext?.User;

                // Prefer claims (NameIdentifier or sub)
                var claimValue = user?.FindFirstValue(ClaimTypes.NameIdentifier)
                                ?? user?.FindFirstValue(JwtRegisteredClaimNames.Sub);

                if (!string.IsNullOrWhiteSpace(claimValue))
                    return claimValue.Trim();

                // Fallback to header if absolutely necessary
                return _httpContextAccessor.HttpContext?.Request.Headers["UserId"].FirstOrDefault();
            }
        }

        public Guid UserGuidId
        {
            get
            {
                if (Guid.TryParse(UserId, out var guid))
                    return guid;
                return Guid.Empty;
            }
        }

        public string UserName =>
            _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? string.Empty;

        public string Email =>
            _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email) ?? string.Empty;

        public string[] Roles =>
            _httpContextAccessor.HttpContext?.User?.FindAll(ClaimTypes.Role)
                ?.Select(r => r.Value)
                .Where(r => !string.IsNullOrWhiteSpace(r))
                .ToArray()
            ?? Array.Empty<string>();

        public bool IsAuthenticated =>
            _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }

}
