using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class EmployeeVerificationConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.EmployeeVerification>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.EmployeeVerification> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.UserProfileId).IsRequired();
            builder.Property(z => z.AgencyName).IsRequired().HasMaxLength(100);
            builder.Property(z => z.InitiatedDate).HasColumnType("date");
            builder.Property(z => z.CompletedDate).HasColumnType("date");
            builder.Property(z => z.AgencyReportUrl).HasMaxLength(256);

            // Enum: store as string
            builder.Property(b => b.VerificationType)
                   .HasConversion<string>()
                   .HasMaxLength(50);

            builder.Property(b => b.Status)
                   .HasConversion<string>()
                   .HasMaxLength(50);

            builder.Property(b => b.Result)
                 .HasConversion<string>()
                 .HasMaxLength(50);

            builder.Property(b => b.IsActive)
               .HasDefaultValue(true);

            builder.HasOne(b => b.UserProfile)
               .WithMany(u => u.EmployeeVerifications)
               .HasForeignKey(b => b.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
