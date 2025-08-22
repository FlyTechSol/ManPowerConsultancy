using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class ExArmyConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.ExArmy>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.ExArmy> builder)
        {
            builder.Property(z => z.ServiceNumber).HasMaxLength(20);
            builder.Property(z => z.Rank).HasMaxLength(50);
            builder.Property(z => z.Unit).HasMaxLength(50);
            builder.Property(z => z.Rank).HasMaxLength(50);
            builder.Property(z => z.TotalService).HasMaxLength(20);
            builder.Property(z => z.ReasonForDischarge).HasMaxLength(200);
            builder.Property(z => z.DischargeCertificateUrl).HasMaxLength(256);

            // Enum: store as string
            builder.Property(b => b.BranchOfService)
                   .HasConversion<string>()
                   .HasMaxLength(20);

            // User relationship
            builder.HasOne(b => b.UserProfile)
               .WithMany(u => u.ExArmies)
               .HasForeignKey(b => b.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
