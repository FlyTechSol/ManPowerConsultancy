using MC.Domain.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class UserGeneralDetailConfiguration : IEntityTypeConfiguration<UserGeneralDetail>
    {
        public void Configure(EntityTypeBuilder<UserGeneralDetail> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(p => p.FatherName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.MotherName).HasMaxLength(100);
            builder.Property(p => p.SpouseName).HasMaxLength(100);
            builder.Property(p => p.IdentityMarks).HasMaxLength(200);

            builder.Property(p => p.MaritalStatus) //store as string e.g. married
                 .HasConversion<string>()
                 .HasMaxLength(20);

            builder.HasOne(p => p.Religion)
                .WithMany()
                .HasForeignKey(p => p.ReligionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Nationality)
                .WithMany()
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.CasteCategory)
                .WithMany()
                .HasForeignKey(p => p.CasteCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.HighestEducation)
                .WithMany()
                .HasForeignKey(p => p.HighestEducationId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
