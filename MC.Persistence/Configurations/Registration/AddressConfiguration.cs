using MC.Domain.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class AddressConfiguration : IEntityTypeConfiguration<MC.Domain.Entity.Registration.Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(z => z.AddressLine1).HasMaxLength(100);
            builder.Property(z => z.AddressLine2).HasMaxLength(100);
            builder.Property(z => z.PinCode).HasMaxLength(10);
            builder.Property(z => z.City).HasMaxLength(150);
            builder.Property(z => z.District).HasMaxLength(150);
            builder.Property(z => z.State).HasMaxLength(100);
            builder.Property(z => z.Country).HasMaxLength(100);
           
            builder.ConfigureAuditFields();

            builder.Property(b => b.AddressType)
                  .HasConversion<string>()
                  .HasMaxLength(50);

            builder.HasOne(a => a.CreatedByUser)
                .WithMany()
                .HasForeignKey(a => a.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.ModifiedByUser)
                .WithMany()
                .HasForeignKey(a => a.ModifiedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.UserProfile)
               .WithMany(u => u.Addresses)
               .HasForeignKey(b => b.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(a => new { a.UserProfileId, a.IsActive })
               .HasDatabaseName("IX_Addresses_UserProfileId_IsActive"); //comosit index for performance
        }
    }
}
