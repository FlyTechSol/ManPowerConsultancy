using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class GunManConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.GunMan>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.GunMan> builder)
        {

            builder.Property(z => z.GunLicenceName).HasMaxLength(100);
            builder.Property(z => z.GunLicenseNumber).HasMaxLength(50);
            builder.Property(z => z.WeaponNumber).HasMaxLength(50);
            builder.Property(z => z.MakeOfCompany).HasMaxLength(100);
            builder.Property(z => z.GunLicenseIssuedBy).HasMaxLength(100);
            builder.Property(z => z.GunLicenseIssuedDate).HasColumnType("date");
            builder.Property(z => z.GunLicenseExpiryDate).HasColumnType("date");
            builder.Property(z => z.GunLicenseRemarks).HasMaxLength(200);
            builder.Property(z => z.Jurisdiction).HasMaxLength(100);
            builder.Property(z => z.LicenceAddress).HasMaxLength(200);

            // Enum: store as string
            builder.Property(b => b.WeaponType)
                   .HasConversion<string>()
                   .HasMaxLength(25);

            // User relationship
            builder.HasOne(b => b.UserProfile)
               .WithMany(u => u.GunMen)
               .HasForeignKey(b => b.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
