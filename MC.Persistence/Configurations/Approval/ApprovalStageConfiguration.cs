using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Approval
{
    public class ApprovalStageConfiguration : IEntityTypeConfiguration<ApprovalStage>
    {
        public void Configure(EntityTypeBuilder<ApprovalStage> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(s => s.WorkflowId).IsRequired();
            builder.Property(s => s.Order).IsRequired();

            builder.Property(b => b.ApprovalMode)
                 .HasConversion<string>()
                 .IsRequired()
                 .HasMaxLength(50);

            builder.HasOne(s => s.Workflow)
               .WithMany(w => w.Stages)
               .HasForeignKey(s => s.WorkflowId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Approvers)
                .WithOne(a => a.Stage)
                .HasForeignKey(a => a.StageId)
                .OnDelete(DeleteBehavior.Cascade);

            Guid UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9");
            DateTime DateCreatedUtc = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc);
            var UserName = "System Admin";
            builder.HasData(
                new ApprovalStage { Id = Guid.Parse("{DBC65A3B-142A-4A90-A46C-168AB69CA695}"), WorkflowId = Guid.Parse("B8517DD6-6C6D-4C2C-8DB7-95CAE11791A6"), Order=1, IsFinalStage = false, ApprovalMode = StageApprovalMode.Sequential, DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new ApprovalStage { Id = Guid.Parse("{B1EF1E9F-F327-4A47-8C2D-E94414872F77}"), WorkflowId = Guid.Parse("B8517DD6-6C6D-4C2C-8DB7-95CAE11791A6"), Order = 2, IsFinalStage = false, ApprovalMode = StageApprovalMode.Sequential, DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new ApprovalStage { Id = Guid.Parse("{B003080E-2752-4B5A-ABF3-D2DA565EE750}"), WorkflowId = Guid.Parse("B8517DD6-6C6D-4C2C-8DB7-95CAE11791A6"), Order = 3, IsFinalStage = true, ApprovalMode = StageApprovalMode.Sequential, DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName }
                );
        }
    }
}
