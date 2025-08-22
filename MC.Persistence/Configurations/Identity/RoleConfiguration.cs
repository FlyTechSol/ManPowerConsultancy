using MC.Domain.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Identity
{
    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(
                new ApplicationRole
                {
                    Id = Guid.Parse("{13BA1D43-1F90-466B-8B67-6AEB5E32581F}"),
                    Name = "Employee",
                    DisplayOrder = 1,
                    NormalizedName = "EMPLOYEE"
                },
                new ApplicationRole
                {
                    Id = Guid.Parse("{94231286-F784-4141-9087-08050F9C0ACF}"),
                    Name = "Supervisor",
                    DisplayOrder = 2,
                    NormalizedName = "SUPERVISOR"
                },
                new ApplicationRole
                {
                    Id = Guid.Parse("{2C157266-193A-4F44-8512-950B1D025408}"),
                    Name = "SiteIncharge",
                    DisplayOrder = 3,
                    NormalizedName = "SITEINCHARGE"
                },
                new ApplicationRole
                {
                    Id = Guid.Parse("{2D149421-8F16-4A0A-869E-EA05653C89F3}"),
                    Name = "Director",
                    DisplayOrder = 3,
                    NormalizedName = "DIRECTOR"
                },
                new ApplicationRole
                {
                    Id = Guid.Parse("{5E7D2008-E189-48AC-B7B2-B7291C697715}"),
                    Name = "Accountant",
                    DisplayOrder = 4,
                    NormalizedName = "ACCOUNTANT"
                },
                new ApplicationRole
                {
                    Id = Guid.Parse("{2CDF7283-EAF0-4F5A-B44A-4DEF5ED91DA8}"),
                    Name = "GeneralManager",
                    DisplayOrder = 5,
                    NormalizedName = "GENERALMANAGER"
                },
                new ApplicationRole
                {
                    Id = Guid.Parse("{BA2E09D3-8A52-48A5-A4A9-178E53D60FDE}"),
                    Name = "Administrator",
                    DisplayOrder = 6,
                    NormalizedName = "ADMINISTRATOR"
                }
            );
        }
    }
}
