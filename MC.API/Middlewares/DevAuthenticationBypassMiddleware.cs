using System.Security.Claims;

namespace MC.API.Middlewares
{
    public class DevAuthenticationBypassMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public DevAuthenticationBypassMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (_env.IsDevelopment() && context.User?.Identity?.IsAuthenticated == false)
            {
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, "dev-user"),
                new Claim(ClaimTypes.NameIdentifier, "dev-user-id"),
                new Claim(ClaimTypes.Role, "Administrator")
            };

                var identity = new ClaimsIdentity(claims, "Dev");
                context.User = new ClaimsPrincipal(identity);
            }
            await _next(context);
        }
    }
}
