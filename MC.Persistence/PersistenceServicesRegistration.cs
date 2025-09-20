using MC.Application.Contracts.Email;
using MC.Application.Contracts.Identity;
using MC.Application.Contracts.Logging;
using MC.Application.Contracts.Navigation;
using MC.Application.Contracts.Persistence;
using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Contracts.Persistence.Common.Download;
using MC.Application.Contracts.Persistence.FileHandling.Upload;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Contracts.Persistence.Menu;
using MC.Application.Contracts.Persistence.Organization;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Contracts.Persistence.Report;
using MC.Application.Contracts.UnitOfWork;
using MC.Application.Settings;
using MC.Persistence.DatabaseContext;
using MC.Persistence.Repositories;
using MC.Persistence.Repositories.Approval;
using MC.Persistence.Repositories.Common;
using MC.Persistence.Repositories.Common.Download;
using MC.Persistence.Repositories.FileHandling;
using MC.Persistence.Repositories.Master;
using MC.Persistence.Repositories.Menu;
using MC.Persistence.Repositories.Navigation;
using MC.Persistence.Repositories.Organization;
using MC.Persistence.Repositories.Registration;
using MC.Persistence.Repositories.Report;
using MC.Persistence.Repositories.UnitOfWork;
using MC.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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
                   // options.UseMySql(
                   //    configuration.GetConnectionString("DatabaseConnectionString"),
                   //    new MySqlServerVersion(new Version(8, 0, 21))
                   //)
                   //.ConfigureWarnings(warnings =>
                   //    warnings.Ignore(RelationalEventId.MultipleCollectionIncludeWarning)
                   //);
            //});
            ////********

            services.AddDbContext<ApplicationDatabaseContext>(options =>
            {
                //options.UseMySql(configuration.GetConnectionString("DatabaseConnectionString"), new MySqlServerVersion(new Version(8, 0, 21)));
                options.UseMySql(
                    configuration.GetConnectionString("DatabaseConnectionString"),
                    new MySqlServerVersion(new Version(8, 0, 21))
                )
                .ConfigureWarnings(warnings =>
                    warnings.Ignore(RelationalEventId.MultipleCollectionIncludeWarning)
                );

            });

            services.Configure<ApplicationConfigSettings>(configuration.GetSection("ApplicationConfig"));
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            //auth related
           

            //Email template
            services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMenuService, MenuService>();

            //report
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<ICsvExportService, CsvExportService>();
            services.AddScoped<IPdfExportService, PdfExportService>();
           
            //approval
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IApprovalActionRepository, ApprovalActionRepository>();
            services.AddScoped<IApprovalEligibilityService, ApprovalEligibilityService>();
            services.AddScoped<IApprovalRequestRepository, ApprovalRequestRepository>();
            services.AddScoped<IApprovalRequestStageRepository, ApprovalRequestStageRepository>();
            services.AddScoped<IApprovalService, ApprovalService>();
            services.AddScoped<IApprovalStageApproverRepository, ApprovalStageApproverRepository>();
            services.AddScoped<IApprovalStageRepository, ApprovalStageRepository>();
            services.AddScoped<IApprovalWorkflowRepository, ApprovalWorkflowRepository>();

            //organization
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IClientMasterRepository, ClientMasterRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();

            //common
            services.AddScoped<IFileUploadRepository, FileUploadRepository>();

            //Menu Service
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();

            //Navigation for multilevel menus
            services.AddScoped<INavigationNodeRepository, NavigationNodeRepository>();
         
            //Registration services
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
            services.AddScoped<IBodyMeasurementRepository, BodyMeasurementRepository>();
            services.AddScoped<ICommunicationRepository, CommunicationRepository>();
            services.AddScoped<IEmployeeVerificationRepository, EmployeeVerificationRepository>();
            services.AddScoped<IEmployeeReferenceRepository, EmployeeReferenceRepository>();
            services.AddScoped<IExArmyRepository, ExArmyRepository>();
            services.AddScoped<IFamilyRepository, FamilyRepository>();
            services.AddScoped<IGunManRepository, GunManRepository>();
            services.AddScoped<IInsuranceNomineeRepository, InsuranceNomineeRepository>();
            services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            services.AddScoped<IPoliceVerificationRepository, PoliceVerificationRepository>();
            services.AddScoped<IPreviousExperienceRepository, PreviousExperienceRepository>();
            services.AddScoped<IRegistrationIdGeneratorRepository, RegistrationIdGeneratorRepository>();
            services.AddScoped<IResignationRepository, ResignationRepository>();
            services.AddScoped<ISecurityDepositRepository, SecurityDepositRepository>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<IUserAssetRepository, UserAssetRepository>();
            services.AddScoped<IUserDocumentRepository, UserDocumentRepository>();
            services.AddScoped<IUserGeneralDetailRepository, UserGeneralDetailRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();

            //Master data services
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<ICasteCategoryRepository, CasteCategoryRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IHighestEducationRepository, HighestEducationRepository>();
            services.AddScoped<IRecruitmentTypeRepository, RecruitmentTypeRepository>();
            services.AddScoped<IReligionRepository, ReligionRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<IZipCodeRepository, ZipCodeRepository>();
            

            return services;
        }
    }
}
