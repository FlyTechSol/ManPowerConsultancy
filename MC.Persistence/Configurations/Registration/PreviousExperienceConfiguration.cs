using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class PreviousExperienceConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.PreviousExperience>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.PreviousExperience> builder)
        {
            builder.Property(z => z.CompanyWorked).HasMaxLength(100);
            builder.Property(z => z.Place).HasMaxLength(100);
            builder.Property(z => z.Duration).HasMaxLength(50);
            builder.Property(z => z.ReasonForLeft).HasMaxLength(200);
            builder.Property(z => z.JoiningDate).HasColumnType("date");
            builder.Property(z => z.LeftDate).HasColumnType("date"); // Assuming date only, no time
            builder.Property(z => z.Remarks).HasMaxLength(200);

            // User relationship
            builder.HasOne(b => b.UserProfile)
               .WithMany(u => u.PreviousExperiences)
               .HasForeignKey(b => b.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
