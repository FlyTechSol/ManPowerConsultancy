using MC.Domain.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(p => p.RegistrationId)
                .IsRequired()
                .HasMaxLength(20); // Adjust as needed

            builder.HasIndex(p => p.RegistrationId)
                .IsUnique(); // enforce uniqueness

            builder.HasOne(p => p.Company)
                .WithMany(c => c.UserProfiles)
                .HasForeignKey(p => p.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ClientMaster)
               .WithMany(c => c.UserProfiles)
               .HasForeignKey(p => p.ClientMasterId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ClientUnit)
               .WithMany(c => c.UserProfiles)
               .HasForeignKey(p => p.ClientUnitId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.MiddleName).HasMaxLength(100);
            builder.Property(p => p.LastName).HasMaxLength(100);
            builder.Property(p => p.AadhaarNumber).IsRequired().HasMaxLength(12); // Assuming Aadhar is 12 digits
            builder.Property(p => p.PanNumber).HasMaxLength(10);
            builder.Property(p => p.UanNumber).HasMaxLength(12);
            builder.Property(p => p.EsicNumber).HasMaxLength(30);
            builder.Property(p => p.Email).HasMaxLength(70);
            builder.Property(p => p.MobileNumber).HasMaxLength(15);
            builder.Property(p => p.AlternatePhoneNumber).HasMaxLength(15);
            builder.Property(p => p.PlaceOfBirth).HasMaxLength(100);
            builder.Property(p => p.IdentityMarks).HasMaxLength(200);
            builder.Property(p => p.ProfilePictureUrl).HasMaxLength(200);
            builder.Property(p => p.DateOfJoining).IsRequired().HasColumnType("date");
            // Relationships (all optional)
            builder.HasOne(p => p.Salutation)
                .WithMany()
                .HasForeignKey(p => p.TitleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Gender)
                .WithMany()
                .HasForeignKey(p => p.GenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.RecruitmentType)
                .WithMany()
                .HasForeignKey(p => p.RecruitmentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.User)
                 .WithOne(u => u.UserProfile)
                 .HasForeignKey<UserProfile>(e => e.UserId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict); // or ClientSetNull

            builder.HasData(
            new UserProfile
            {
                Id = Guid.Parse("ED8E68C4-4DF4-4989-9155-FED3052D8D25"),
                CompanyId = Guid.Parse("489D4544-5461-4132-AA29-688758627C98"),
                ClientMasterId = Guid.Parse("8A4A5A20-7236-46E4-9739-8AB7A47F554E"),
                ClientUnitId = Guid.Parse("2654AB1A-DC1D-4B93-9249-9CD4F9228968"),
                BranchId = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000001"),
                DesignationId = Guid.Parse("F0A87667-1BC3-4688-85FB-BC656DA4BF9F"),
                CategoryId = Guid.Parse("25082EC5-82BF-4D5C-86F6-42F50AFF16A6"),
                UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                TitleId = Guid.Parse("AD77F3F7-CF8A-4F72-A38D-F9AAADE1D79F"),
                FirstName = "System",
                MiddleName = "",
                LastName = "Admin",
                AadhaarNumber = "987654321001",
                RegistrationId = "MFC -0100",
                DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
            },
            new UserProfile
            {
                Id = Guid.Parse("83B6730A-C27C-4898-A7CA-29AD3B59213A"),
                CompanyId = Guid.Parse("74C8B851-922F-45B9-9C28-0C53C06120AA"),
                ClientMasterId = Guid.Parse("8A4A5A20-7236-46E4-9739-8AB7A47F554E"),
                ClientUnitId = Guid.Parse("2654AB1A-DC1D-4B93-9249-9CD4F9228968"),
                BranchId = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000001"),
                DesignationId = Guid.Parse("F0A87667-1BC3-4688-85FB-BC656DA4BF9F"),
                CategoryId = Guid.Parse("25082EC5-82BF-4D5C-86F6-42F50AFF16A6"),
                UserId = Guid.Parse("9e224968-33e4-4652-b7b7-8574d048cdb9"),
                TitleId = Guid.Parse("AD77F3F7-CF8A-4F72-A38D-F9AAADE1D79F"),
                FirstName = "System",
                MiddleName = "",
                LastName = "User",
                AadhaarNumber = "987654321002",
                RegistrationId = "MSO -1000",
                DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
            }
        );
        }
    }
}
