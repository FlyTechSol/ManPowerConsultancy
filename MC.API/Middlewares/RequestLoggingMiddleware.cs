using System.Security.Claims;

namespace MC.API.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;

            _logger.LogInformation("Authorization header: {auth}", context.Request.Headers["Authorization"].ToString());

            // Log basic request info
            _logger.LogInformation("Incoming Request: {method} {path}", request.Method, request.Path);

            // Log matched endpoint
            var endpoint = context.GetEndpoint();
            if (endpoint != null)
                _logger.LogInformation("Matched Endpoint: {endpoint}", endpoint.DisplayName);
            else
                _logger.LogWarning("No endpoint matched for this request.");

            // Log all claims even if user not authenticated
            if (context.User?.Claims != null)
            {
                foreach (var claim in context.User.Claims)
                {
                    _logger.LogInformation("Claim: {type} = {value}", claim.Type, claim.Value);
                }
            }

            // Authenticated user info
            _logger.LogInformation("IsAuthenticated: {auth}", context.User.Identity?.IsAuthenticated ?? false);

            if (context.User.Identity?.IsAuthenticated == true)
            {
                var userId = context.User.FindFirst("uid")?.Value ?? context.User.Identity.Name;
                var roles = context.User.FindAll(ClaimTypes.Role).Select(r => r.Value);
                _logger.LogInformation("Authenticated User: {user}, Roles: {roles}", userId, string.Join(", ", roles));
            }
            else
            {
                _logger.LogInformation("Unauthenticated request — likely login or token missing/invalid.");
            }

            await _next(context);
        }


        //public async Task InvokeAsync(HttpContext context)
        //{
        //    var request = context.Request;

        //    // Log basic request info
        //    _logger.LogInformation("Incoming Request: {method} {path}", request.Method, request.Path);

        //    // Log matched endpoint (if available)
        //    var endpoint = context.GetEndpoint();
        //    if (endpoint != null)
        //    {
        //        _logger.LogInformation("Matched Endpoint: {endpoint}", endpoint.DisplayName);
        //    }
        //    else
        //    {
        //        _logger.LogWarning("No endpoint matched for this request.");
        //    }

        //    // Log authenticated user (if available)
        //    if (context.User.Identity?.IsAuthenticated == true)
        //    {
        //        //var userId = context.User.FindFirst("uid")?.Value ?? context.User.Identity.Name;
        //        //_logger.LogInformation("Authenticated User: {user}", userId);
        //        if (context.User.Identity?.IsAuthenticated == true)
        //        {
        //            var userId = context.User.FindFirst("uid")?.Value ?? context.User.Identity.Name;
        //            var roles = context.User.FindAll(ClaimTypes.Role).Select(r => r.Value);
        //            _logger.LogInformation("Authenticated User: {user}, Roles: {roles}", userId, string.Join(", ", roles));
        //        }
        //    }

        //    await _next(context);
        //}
    }
}
