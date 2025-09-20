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
                //new Claim(ClaimTypes.Name, "System HR"),
                //new Claim(ClaimTypes.NameIdentifier, "2e9cfc1e-c228-41b5-bada-2f859ec9de32"), //new Claim(ClaimTypes.NameIdentifier, "dev-user-id"),
                //new Claim(ClaimTypes.Email, "hr@localhost.com"),
                //new Claim(ClaimTypes.Role, "HR")
                new Claim(ClaimTypes.Name, "System Admin"),
                new Claim(ClaimTypes.NameIdentifier, "8e445865-a24d-4543-a6c6-9443d048cdb9"), //new Claim(ClaimTypes.NameIdentifier, "dev-user-id"),
                new Claim(ClaimTypes.Email, "admin@localhost.com"),
                new Claim(ClaimTypes.Role, "Administrator")
                };

                var identity = new ClaimsIdentity(claims, "Dev");
                context.User = new ClaimsPrincipal(identity);
            }
            await _next(context);
        }
    }
}
