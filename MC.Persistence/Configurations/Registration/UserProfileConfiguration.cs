using MC.Domain.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasIndex(p => p.RegistrationId).IsUnique();

            // Aadhar
            builder.Property(p => p.AadharNo)
                .HasMaxLength(12); // Assuming Aadhar is 12 digits

            builder.Property(p => p.PanNo)
               .HasMaxLength(10);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.MiddleName).HasMaxLength(100);
            builder.Property(p => p.LastName).HasMaxLength(100);

            builder.Property(p => p.Email).HasMaxLength(150);
            builder.Property(p => p.MobileNumber).HasMaxLength(15);
            builder.Property(p => p.AlternatePhoneNumber).HasMaxLength(15);
            builder.Property(p => p.FatherName).HasMaxLength(100);
            builder.Property(p => p.MotherName).HasMaxLength(100);
            builder.Property(p => p.PlaceOfBirth).HasMaxLength(100);
            builder.Property(p => p.UanNumber).HasMaxLength(20);
            builder.Property(p => p.EsicNumber).HasMaxLength(20);
            builder.Property(p => p.IdentityMarks).HasMaxLength(200);

            builder.Property(p => p.MaritalStatus) //store as string e.g. married
                 .HasConversion<string>()
                 .HasMaxLength(20);

            // Relationships (all optional)
            builder.HasOne(p => p.Salutation)
                .WithMany()
                .HasForeignKey(p => p.TitleId)
                .OnDelete(DeleteBehavior.Restrict);

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

            builder.HasOne(p => p.Gender)
                .WithMany()
                .HasForeignKey(p => p.GenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.HighestEducation)
                .WithMany()
                .HasForeignKey(p => p.HighestEducationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.RecruitmentType)
                .WithMany()
                .HasForeignKey(p => p.RecruitmentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.User)
                .WithOne(u => u.UserProfile)
                .HasForeignKey<UserProfile>(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
