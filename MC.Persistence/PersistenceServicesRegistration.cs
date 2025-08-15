using MC.Application.Contracts.Email;
using MC.Application.Contracts.Identity;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Persistence;
using MC.Application.Settings;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Repositories;
using MC.Persistence.Repositories.Common;
using MC.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            /////**********
            //var envVarKey = configuration["ApplicationConfig:ConnectionStringKey"];
            //if (string.IsNullOrEmpty(envVarKey))
            //    throw new InvalidOperationException("ConnectionStringKey is not configured in ApplicationConfig section.");

            //// Get actual connection string from environment variable
            //var connectionString = Environment.GetEnvironmentVariable(envVarKey);
            //if (string.IsNullOrEmpty(connectionString))
            //    throw new InvalidOperationException($"Environment variable '{envVarKey}' is not set.");

            //services.AddDbContext<ApplicationDatabaseContext>(options =>
            //{
            //    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)));
            //});
            ////********

            services.AddDbContext<ApplicationDatabaseContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("DatabaseConnectionString"), new MySqlServerVersion(new Version(8, 0, 21)));
            });

            services.Configure<ApplicationConfigSettings>(configuration.GetSection("ApplicationConfig"));
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            //Email template
            services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMenuService, MenuService>();

            return services;
        }
    }
}
