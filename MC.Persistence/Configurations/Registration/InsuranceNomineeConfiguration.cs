using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class InsuranceNomineeConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.InsuranceNominee>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.InsuranceNominee> builder)
        {
            builder.Property(z => z.NominatedBy).IsRequired().HasMaxLength(100);
            builder.Property(z => z.NominatedByFather).IsRequired().HasMaxLength(100);
            builder.Property(z => z.SoldierNumber).HasMaxLength(20);
            builder.Property(z => z.SoldierRank).HasMaxLength(50);
            builder.Property(z => z.SoldierUnit).HasMaxLength(50);
            builder.Property(z => z.NominatedByPermanentAddress).HasMaxLength(200);
            builder.Property(z => z.NominatedByCorrespondenceAddress).HasMaxLength(200);
            builder.Property(z => z.NomineeName).IsRequired().HasMaxLength(100);
            builder.Property(z => z.RelationWithNominee).IsRequired().HasMaxLength(50);
            builder.Property(z => z.NomineeFather).IsRequired().HasMaxLength(100);
            builder.Property(z => z.NomineeByPermanentAddress).HasMaxLength(200);
            builder.Property(z => z.NomineeByCorrespondenceAddress).HasMaxLength(200);
            builder.Property(z => z.NominatedByDoB).HasColumnType("date");
            builder.Property(z => z.NomineeDoB).IsRequired().HasColumnType("date");

            // User relationship
            builder.HasOne(b => b.UserProfile)
               .WithMany(u => u.InsuranceNominees)
               .HasForeignKey(b => b.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}