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
                     //FirstName = "System",
                     //LastName = "Admin",
                     UserName = "admin@localhost.com",
                     NormalizedUserName = "ADMIN@LOCALHOST.COM",
                     //PasswordHash = hasher.HashPassword(null, "Password@123"),
                     PasswordHash = "AQAAAAIAAYagAAAAEIZEnobWLWVm+KqYua3eConzPpMHEraORI5xGWGyIXsrYHZGO8Z/Fgvj2Frc+Wex8A==",
                     EmailConfirmed = true,
                     ConcurrencyStamp = "905afbf7-cb82-4046-aab6-2e634a9fc0cc", // fixed
                     //UserProfile = profile,
                 },
                 new ApplicationUser
                 {
                     Id = Guid.Parse("9e224968-33e4-4652-b7b7-8574d048cdb9"),
                     Email = "user@localhost.com",
                     NormalizedEmail = "USER@LOCALHOST.COM",
                     //FirstName = "System",
                     //LastName = "Student",
                     UserName = "user@localhost.com",
                     NormalizedUserName = "USER@LOCALHOST.COM",
                     //PasswordHash = hasher.HashPassword(null, "Password@123"),
                     PasswordHash = "AQAAAAIAAYagAAAAEOq0WMnbfCDHwU/jNJl2v/3I4IpjEpTT39fO3H64akUI1TXP1XuJfNm6+l9OGk0mjQ==",
                     EmailConfirmed = true,
                     ConcurrencyStamp = "A494A604-0DEA-42B2-B262-BDEAFC80F7E1", // fixed
                     //UserProfile = profile1,
                 }
            );
        }
    }
}
