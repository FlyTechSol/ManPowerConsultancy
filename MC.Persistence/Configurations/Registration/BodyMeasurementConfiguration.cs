using MC.Domain.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class BodyMeasurementConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.BodyMeasurement>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.BodyMeasurement> builder)
        {
            builder.HasOne(e => e.UserProfile)
               .WithOne(u => u.BodyMeasurement)
               .HasForeignKey<BodyMeasurement>(e => e.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            // Optional double properties
            builder.Property(b => b.HeightCm).HasPrecision(5, 2);
            builder.Property(b => b.WeightKg).HasPrecision(5, 2);
            builder.Property(b => b.ChestCm).HasPrecision(5, 2);
            builder.Property(b => b.ShoulderCm).HasPrecision(5, 2);

            // Enum: store as string
            builder.Property(b => b.HairColour)
                   .HasConversion<string>()
                   .HasMaxLength(20);

            builder.Property(b => b.EyeColour)
                   .HasConversion<string>()
                   .HasMaxLength(20);
        }
    }
}
