using MC.Domain.Entity.Approval;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Approval
{
    public class ApprovalRequestConfiguration : IEntityTypeConfiguration<ApprovalRequest>
    {
        public void Configure(EntityTypeBuilder<ApprovalRequest> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.ApprovalWorkflowId).IsRequired();
            builder.Property(z => z.RequestedBy).IsRequired();
            builder.Property(z => z.RequestEntityId).IsRequired();

            builder.Property(b => b.Status)
                 .HasConversion<string>()
                 .IsRequired()
                 .HasMaxLength(50);

            builder.Property(b => b.RequestType)
                .HasConversion<string>()  
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(r => r.Workflow)
                .WithMany(w => w.Requests)   
                .HasForeignKey(r => r.ApprovalWorkflowId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.RequestedUser)
                .WithMany()
                .HasForeignKey(r => r.RequestedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.Stages)
                .WithOne(s => s.Request)
                .HasForeignKey(s => s.ApprovalRequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
