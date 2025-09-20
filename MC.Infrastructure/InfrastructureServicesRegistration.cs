using MC.Application.Contracts.Email;
using MC.Application.Contracts.Identity;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence.FileHandling;
using MC.Infrastructure.Email;
using MC.Infrastructure.FileHandling;
using MC.Infrastructure.Identity;
using MC.Infrastructure.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IFileStorageService, FileStorageService>();

            return services;
        }
    }
}
