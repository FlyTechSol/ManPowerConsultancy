using MC.Domain.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class SecurityDepositConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.SecurityDeposit>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.SecurityDeposit> builder)
        {
            builder.ConfigureAuditFields();

            builder.HasOne(e => e.UserProfile)
              .WithOne(u => u.SecurityDeposit)
              .HasForeignKey<SecurityDeposit>(e => e.UserProfileId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade);

            builder.Property(b => b.ReciptNumber).IsRequired().HasMaxLength(15);
            builder.Property(b => b.Amount).IsRequired().HasPrecision(10, 2);
            builder.Property(b => b.RefundableAmount).HasPrecision(10, 2);
            builder.Property(b => b.NonRefundableAmount).HasPrecision(10, 2);
            builder.Property(b => b.ReceiptDate).HasColumnType("date");
            builder.Property(b => b.Remark).HasMaxLength(200);

        }
    }
}