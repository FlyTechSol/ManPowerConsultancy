using MC.Domain.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class CommunicationConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.Communication>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.Communication> builder)
        {
            builder.ConfigureAuditFields();

            builder.HasOne(e => e.UserProfile)
               .WithOne(u => u.Communication)
               .HasForeignKey<Communication>(e => e.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            builder.Property(b => b.PersonalMobileNumber).IsRequired().HasMaxLength(15);
            builder.Property(b => b.OfficialMobileNumber).HasMaxLength(15);
            builder.Property(b => b.EmergencyContactNumber).IsRequired().HasMaxLength(15);
            builder.Property(b => b.LandlineNumber1).HasMaxLength(15);
            builder.Property(b => b.LandlineNumber2).HasMaxLength(15);
            builder.Property(b => b.PersonalEmail).HasMaxLength(70);
            builder.Property(b => b.OfficialEmail).HasMaxLength(70);

        }
    }
}