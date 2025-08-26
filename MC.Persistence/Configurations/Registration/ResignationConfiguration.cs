using MC.Domain.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class ResignationConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.Resignation>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.Resignation> builder)
        {
            builder.ConfigureAuditFields();

            builder.HasOne(e => e.UserProfile)
               .WithOne(u => u.Resignations)
               .HasForeignKey<Resignation>(e => e.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            // Optional double properties
            builder.Property(b => b.Reason).IsRequired().HasMaxLength(200);
           
        }
    }
}