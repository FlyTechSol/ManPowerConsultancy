using MC.Domain.Entity.Identity;
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
                     PasswordHash = "AQAAAAIAAYagAAAAEKe0E7y2rQdK+GhaNp/XHQKu1BjS0CUfXokbwqCQ0beQTTf1UnrdMYTE6ImHUHNOBg==",
                     EmailConfirmed = true,
                     ConcurrencyStamp = "905afbf7-cb82-4046-aab6-2e634a9fc0cc", // fixed
                     //TitleId = Guid.Parse("{AD77F3F7-CF8A-4F72-A38D-F9AAADE1D79F}")
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
                     PasswordHash = "AQAAAAIAAYagAAAAEJ8vosGG0/vkaAsWru7OsRAJ37UHlJOoE0D0Z2sccMwgG+pq0cLjXcGad2NFj46AEA==",
                     EmailConfirmed = true,
                     ConcurrencyStamp = "A494A604-0DEA-42B2-B262-BDEAFC80F7E1", // fixed
                     //TitleId = Guid.Parse("{AD77F3F7-CF8A-4F72-A38D-F9AAADE1D79F}")
                 }
            );
        }
    }
}
