using MC.Application.Contracts.Identity;
using MC.Domain.Base;
using MC.Domain.Entity.Common;
using MC.Domain.Entity.Identity;
using MC.Domain.Entity.Master;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MC.Persistence.Configurations;
using MC.Domain.Entity.Menu;

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
        //common configurations
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());

            builder.ApplyConfiguration(new TitlesConfiguration());
            builder.ApplyConfiguration(new GendersConfiguration());

            //builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDatabaseContext).Assembly);
            
            builder.Entity<IdentityUserRole<Guid>>().HasKey(ur => new { ur.UserId, ur.RoleId });
            builder.Entity<IdentityUserLogin<Guid>>().HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });
            builder.Entity<IdentityUserToken<Guid>>().HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });


            builder.Entity<ApplicationUser>()
            .HasOne(u => u.Title)
            .WithMany()
            .HasForeignKey(u => u.TitleId)
            .OnDelete(DeleteBehavior.Restrict); // Optional: avoid cascade delete
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
                    entry.Entity.ModifiedByUserId = Guid.Parse(_userContext.UserId);
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.UtcNow;
                    if (!string.IsNullOrWhiteSpace(_userContext.UserId))
                        entry.Entity.CreatedByUserId = Guid.Parse(_userContext.UserId);
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
