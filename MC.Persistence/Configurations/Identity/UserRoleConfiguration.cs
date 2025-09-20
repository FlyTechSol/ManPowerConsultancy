using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Identity
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasData(
                //new IdentityUserRole<Guid>
                //{
                //    RoleId = Guid.Parse("{13BA1D43-1F90-466B-8B67-6AEB5E32581F}"),
                //    UserId = Guid.Parse("9e224968-33e4-4652-b7b7-8574d048cdb9")
                //},
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("{BA2E09D3-8A52-48A5-A4A9-178E53D60FDE}"),
                    UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("{A03DF03E-0CA2-4C5A-808A-626BFC2B9AE8}"),
                    UserId = Guid.Parse("2E9CFC1E-C228-41B5-BADA-2F859EC9DE32")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("{88BD4B2E-BC97-4666-B032-AC61F5C00477}"),
                    UserId = Guid.Parse("38CCEE5B-9EAB-49A0-A30F-D6CB52E7D11D")
                }
            );
        }
    }
}
