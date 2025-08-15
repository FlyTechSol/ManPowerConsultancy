using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Persistence.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("{13BA1D43-1F90-466B-8B67-6AEB5E32581F}"),
                    UserId = Guid.Parse("9e224968-33e4-4652-b7b7-8574d048cdb9")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("{BA2E09D3-8A52-48A5-A4A9-178E53D60FDE}"),
                    UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                }
            );
        }
    }
}
