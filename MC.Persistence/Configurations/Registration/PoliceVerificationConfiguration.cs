using MC.Domain.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class PoliceVerificationConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.PoliceVerification>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.PoliceVerification> builder)
        {
            builder.ConfigureAuditFields();

            builder.HasOne(e => e.UserProfile)
               .WithOne(u => u.PoliceVerifications)
               .HasForeignKey<PoliceVerification>(e => e.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            // Optional double properties
            builder.Property(b => b.PoliceStationName).IsRequired().HasMaxLength(100);
            builder.Property(b => b.VerificationRemarks).HasMaxLength(200);

            // Enum: store as string
            builder.Property(b => b.VerificationStatus)
                   .HasConversion<string>()
                   .HasMaxLength(20);
        }
    }
}