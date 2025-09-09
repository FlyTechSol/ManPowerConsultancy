using MC.Application.Contracts.Email;
using MC.Application.Contracts.Identity;
using MC.Application.Contracts.Logging;
using MC.Infrastructure.Email;
using MC.Infrastructure.Identity;
using MC.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace MC.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmailSenderRepository, EmailSenderRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));

            // Required for IHttpContextAccessor
            services.AddHttpContextAccessor();

            // User context
            services.AddScoped<IUserContext, UserContext>();

            return services;
        }
    }
}
