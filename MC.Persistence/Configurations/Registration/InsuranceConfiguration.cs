 using MC.Domain.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class InsuranceConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.Insurance>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.Insurance> builder)
        {

            builder.Property(z => z.InsuranceCompanyName).HasMaxLength(100);
            builder.Property(z => z.PolicyNumber).HasMaxLength(50);
            builder.Property(z => z.PolicyStartDate).HasColumnType("date");
            builder.Property(z => z.PolicyEndDate).HasColumnType("date");
            builder.Property(z => z.PolicyRemarks).HasMaxLength(200);

            // User relationship
            builder.HasOne(e => e.UserProfile)
               .WithOne(u => u.Insurance)
               .HasForeignKey<Insurance>(e => e.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}