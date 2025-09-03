using MC.Application.Contracts.Identity;
using MC.Domain.Base;
using MC.Domain.Entity.Common;
using MC.Domain.Entity.Enum;
using MC.Domain.Entity.Identity;
using MC.Domain.Entity.Master;
using MC.Domain.Entity.Menu;
using MC.Domain.Entity.Navigation;
using MC.Domain.Entity.Organization;
using MC.Domain.Entity.Registration;
using MC.Persistence.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MC.Persistence.DatabaseContext
{
    public class ApplicationDatabaseContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>  // Inherit from IdentityDbContext
    {
        private readonly IUserContext _userContext;

        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options, IUserContext userContext)
            : base(options)
        {
            this._userContext = userContext;
        }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        //Menu configurations
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<NavigationNodeRole> NavigationNodeRoles { get; set; }
        public DbSet<NavigationNode> NavigationNodes { get; set; }

        //common configuration
        public DbSet<EmailTemplate> EmailTemplates { get; set; }

        //master
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<CasteCategory> CasteCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<HighestEducation> HighestEducations { get; set; }
        public DbSet<RecruitmentType> RecruitmentTypes { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<ZipCode> ZipCodes { get; set; }

        //Organization
        public DbSet<Company> Companies { get; set; }
        public DbSet<ClientMaster> ClientMasters { get; set; }
        public DbSet<ClientUnit> ClientUnits { get; set; }

        //registration
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BodyMeasurement> BodyMeasurements { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<EmployeeReference> EmployeeReferences { get; set; }
        public DbSet<ExArmy> ExArmies { get; set; }
        public DbSet<Family> Famlies { get; set; }
        public DbSet<GunMan> GunMen { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<InsuranceNominee> InsuranceNominees { get; set; }
        public DbSet<PoliceVerification> PoliceVerifications { get; set; }
        public DbSet<PreviousExperience> PreviousExperiences { get; set; }
        public DbSet<RegistrationSequence> RegistrationSequences { get; set; }
        public DbSet<Resignation> Resignations { get; set; }
        public DbSet<SecurityDeposit> SecurityDeposits { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<UserAsset> UserAssets { get; set; }
        public DbSet<UserGeneralDetail> UserGeneralDetails { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //builder.ApplyConfiguration(new RoleConfiguration());
            //builder.ApplyConfiguration(new UserConfiguration());
            //builder.ApplyConfiguration(new UserRoleConfiguration());

            //builder.ApplyConfiguration(new TitlesConfiguration());
            //builder.ApplyConfiguration(new GendersConfiguration());

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDatabaseContext).Assembly);

            builder.Entity<IdentityUserRole<Guid>>().HasKey(ur => new { ur.UserId, ur.RoleId });
            builder.Entity<IdentityUserLogin<Guid>>().HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });
            builder.Entity<IdentityUserToken<Guid>>().HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });

            var emailTemplateTypeConverter = new ValueConverter<EmailTemplateType, string>(
                v => v.ToString(),
                v => (EmailTemplateType)Enum.Parse(typeof(EmailTemplateType), v));

            builder.Entity<EmailTemplate>()
                .Property(e => e.TemplateName)
                .HasConversion(emailTemplateTypeConverter);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.EnableSensitiveDataLogging();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.UtcNow;
                if (!string.IsNullOrWhiteSpace(_userContext.UserId))
                {
                    entry.Entity.ModifiedByUserId = Guid.Parse(_userContext.UserId);
                    entry.Entity.ModifiedByUserName = _userContext.UserName ?? Defaults.Users.Unknown;
                }
                    
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.UtcNow;
                    if (!string.IsNullOrWhiteSpace(_userContext.UserId))
                    {
                        entry.Entity.CreatedByUserId = Guid.Parse(_userContext.UserId);
                        entry.Entity.CreatedByUserName = _userContext.UserName ?? Defaults.Users.Unknown;
                    }
                        
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
