using MC.Domain.Entity.Approval;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Approval
{
    public class ApprovalActionConfiguration : IEntityTypeConfiguration<ApprovalAction>
    {
        public void Configure(EntityTypeBuilder<ApprovalAction> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.RequestStageId).IsRequired();
            builder.Property(z => z.ApproverId).IsRequired();
            builder.Property(z => z.Comments).HasMaxLength(200);

            builder.Property(b => b.Action)
                 .HasConversion<string>()
                 .HasMaxLength(50);

            // Navigation relationships (optional but recommended)
            builder.HasOne(a => a.RequestStage)
                   .WithMany(s => s.Actions)
                   .HasForeignKey(a => a.RequestStageId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Approver)
                   .WithMany()
                   .HasForeignKey(a => a.ApproverId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
