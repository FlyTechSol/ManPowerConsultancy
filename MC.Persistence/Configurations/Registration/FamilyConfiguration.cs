using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class FamilyConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.Family>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.Family> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Name).HasMaxLength(100);
            builder.Property(z => z.Address).HasMaxLength(200);
            builder.Property(z => z.RelationTo).HasMaxLength(50);
            builder.Property(z => z.UserProfileId).IsRequired();
            builder.Property(z => z.IsPFNominee).IsRequired();

            builder.Property(b => b.Relationship)
                  .HasConversion<string>()
                  .HasMaxLength(20);

            // User relationship
            builder.HasOne(b => b.UserProfile)
               .WithMany(u => u.Families)
               .HasForeignKey(b => b.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}