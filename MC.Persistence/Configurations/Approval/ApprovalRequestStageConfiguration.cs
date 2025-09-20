using MC.Domain.Entity.Approval;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Approval
{
    public class ApprovalRequestStageConfiguration : IEntityTypeConfiguration<ApprovalRequestStage>
    {
        public void Configure(EntityTypeBuilder<ApprovalRequestStage> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.ApprovalRequestId).IsRequired();
            builder.Property(z => z.ApprovalStageId).IsRequired();
         
            builder.Property(b => b.Status)
                 .HasConversion<string>()
                 .IsRequired()
                 .HasMaxLength(50);

            builder.HasOne(rs => rs.Request)
                   .WithMany(r => r.Stages)
                   .HasForeignKey(rs => rs.ApprovalRequestId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rs => rs.Stage)
                   .WithMany()  // usually we don’t need back navigation from Stage → RequestStages
                   .HasForeignKey(rs => rs.ApprovalStageId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(rs => rs.Actions)
                   .WithOne(a => a.RequestStage)
                   .HasForeignKey(a => a.RequestStageId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
