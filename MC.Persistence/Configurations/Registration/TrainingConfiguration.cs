using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class TrainingConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.Training>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.Training> builder)
        {
            builder.Property(z => z.TrainingName).HasMaxLength(100);
            builder.Property(z => z.TrainingInstitute).HasMaxLength(100);
            builder.Property(z => z.TrainingStartDate).HasColumnType("date"); // Assuming date only, no time
            builder.Property(z => z.TrainingEndDate).HasColumnType("date"); // Assuming date only, no time
            builder.Property(z => z.TrainingRemarks).HasMaxLength(200);
            builder.Property(z => z.TrainingCertificateUrl).HasMaxLength(256);

            // User relationship
            builder.HasOne(b => b.UserProfile)
               .WithMany(u => u.Trainings)
               .HasForeignKey(b => b.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
