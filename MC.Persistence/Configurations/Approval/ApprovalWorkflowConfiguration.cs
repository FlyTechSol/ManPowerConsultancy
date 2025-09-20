using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Approval
{
    public class ApprovalWorkflowConfiguration : IEntityTypeConfiguration<ApprovalWorkflow>
    {
        public void Configure(EntityTypeBuilder<ApprovalWorkflow> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(s => s.CompanyId).IsRequired();

            builder.Property(w => w.WorkflowType)
               .HasConversion<string>() // stores as string, e.g., "LeaveApproval"
               .IsRequired().HasMaxLength(50);

            builder.HasOne(w => w.Company)
               .WithMany()
               .HasForeignKey(w => w.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(w => w.Stages)
                .WithOne(s => s.Workflow)
                .HasForeignKey(s => s.ApprovalWorkflowId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(w => w.Requests)
                .WithOne(r => r.Workflow)
                .HasForeignKey(r => r.ApprovalWorkflowId)
                .OnDelete(DeleteBehavior.Cascade);

            //Guid UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9");
            //DateTime DateCreatedUtc = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc);
            //var UserName = "System Admin";
            //builder.HasData(
            //    new ApprovalWorkflow { Id = Guid.Parse("{B8517DD6-6C6D-4C2C-8DB7-95CAE11791A6}"), WorkflowType = WorkflowType.ProfileApproval, CompanyId = Guid.Parse("489D4544-5461-4132-AA29-688758627C98"), DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName }
            //    );
        }
    }
}
