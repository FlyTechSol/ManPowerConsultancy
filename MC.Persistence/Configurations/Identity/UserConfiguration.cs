using MC.Application.Helper;
using MC.Domain.Entity.Identity;
using MC.Domain.Entity.Registration;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                     Email = "admin@localhost.com",
                     NormalizedEmail = "ADMIN@LOCALHOST.COM",
                     UserName = "admin@localhost.com",
                     NormalizedUserName = "ADMIN@LOCALHOST.COM",
                     //PasswordHash = hasher.HashPassword(null, "Password@123"),
                     PasswordHash = "AQAAAAIAAYagAAAAEIZEnobWLWVm+KqYua3eConzPpMHEraORI5xGWGyIXsrYHZGO8Z/Fgvj2Frc+Wex8A==",
                     EmailConfirmed = true,
                     ConcurrencyStamp = "905afbf7-cb82-4046-aab6-2e634a9fc0cc", // fixed
                 },
                 new ApplicationUser
                 {
                     Id = Guid.Parse("2E9CFC1E-C228-41B5-BADA-2F859EC9DE32"),
                     Email = "hr@localhost.com",
                     NormalizedEmail = "HR@LOCALHOST.COM",
                     UserName = "hr@localhost.com",
                     NormalizedUserName = "HR@LOCALHOST.COM",
                     //PasswordHash = hasher.HashPassword(null, "Password@123"),
                     PasswordHash = "AQAAAAIAAYagAAAAECGbYsKKzFkirUhdIdsX5TILfgFqOGd4ahSusBphPeyIET5sywM7o7zfaTXbWNpKeQ==",
                     EmailConfirmed = true,
                     ConcurrencyStamp = "A494A604-0DEA-42B2-B262-BDEAFC80F7E1", // fixed
                },
                 new ApplicationUser
                 {
                     Id = Guid.Parse("38CCEE5B-9EAB-49A0-A30F-D6CB52E7D11D"),
                     Email = "hrhead@localhost.com",
                     NormalizedEmail = "HRHEAD@LOCALHOST.COM",
                     UserName = "hrhead@localhost.com",
                     NormalizedUserName = "HRHEAD@LOCALHOST.COM",
                     //PasswordHash = hasher.HashPassword(null, "Password@123"),
                     PasswordHash = "AQAAAAIAAYagAAAAEHnbMxFSYD2om+wFtkEh2Arc9PZSDcfmJMAbQ3K5tQn8NRBx5rp9pwzi6DxxE4bQgg==",
                     EmailConfirmed = true,
                     ConcurrencyStamp = "A494A604-0DEA-42B2-B262-BDEAFC80F7E1", // fixed
                 }
            );
        }
    }
}
