using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class UserAssetConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.UserAsset>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.UserAsset> builder)
        {
            builder.Property(z => z.SerialNo).HasMaxLength(30);
            builder.Property(z => z.Remarks).HasMaxLength(200);
            builder.Property(z => z.AssetValue).HasPrecision(18, 2);
            builder.Property(z => z.Quantity).HasPrecision(9, 0);

            // Enum: store as string
            builder.Property(b => b.ReturnStatus)
                   .HasConversion<string>()
                   .HasMaxLength(20);

            // User relationship
            builder.HasOne(b => b.UserProfile)
               .WithMany(u => u.UserAssets)
               .HasForeignKey(b => b.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
