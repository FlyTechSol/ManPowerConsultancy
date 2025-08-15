using MC.Application.Contracts.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

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
                // Prefer claims, fallback to header if needed
                var claimValue = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(claimValue))
                    return claimValue;

                // Only use header if absolutely needed
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
            _httpContextAccessor.HttpContext?.User?.FindAll(ClaimTypes.Role)?.Select(r => r.Value).ToArray()
            ?? Array.Empty<string>();

        public bool IsAuthenticated =>
            _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    }
}
