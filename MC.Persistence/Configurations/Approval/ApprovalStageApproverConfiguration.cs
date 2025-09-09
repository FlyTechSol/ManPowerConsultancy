using MC.Domain.Entity.Approval;
using MC.Domain.Entity.Enum.Approval;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Approval
{
    public class ApprovalStageApproverConfiguration : IEntityTypeConfiguration<ApprovalStageApprover>
    {
        public void Configure(EntityTypeBuilder<ApprovalStageApprover> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(s => s.StageId).IsRequired();
            builder.Property(s => s.StageId).IsRequired();

            // Nullable FKs → no IsRequired()
            builder.Property(s => s.DesignationId).IsRequired(false);
            builder.Property(s => s.UserId).IsRequired(false);

            builder.HasOne(s => s.Stage)
                   .WithMany(st => st.Approvers)
                   .HasForeignKey(s => s.StageId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Designation)
                   .WithMany()
                   .HasForeignKey(s => s.DesignationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.User)
                   .WithMany()
                   .HasForeignKey(s => s.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            Guid UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9");
            DateTime DateCreatedUtc = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc);
            var UserName = "System Admin";
            builder.HasData(
                new ApprovalStageApprover { Id = Guid.Parse("{DB1F43F1-77F1-40B5-93AC-10209F66A4F7}"), StageId = Guid.Parse("{DBC65A3B-142A-4A90-A46C-168AB69CA695}"), UserId = Guid.Parse("08ddeecf-697f-4ac9-8c62-6bc3e7ed5640"), IsMandatory = true, DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new ApprovalStageApprover { Id = Guid.Parse("{6A122142-5F03-4087-B533-2627BBDF7805}"), StageId = Guid.Parse("{B1EF1E9F-F327-4A47-8C2D-E94414872F77}"), DesignationId = Guid.Parse("a2d980ac-3fb9-4eed-a5e1-918b64285f05"), IsMandatory = true, DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new ApprovalStageApprover { Id = Guid.Parse("{4CEC1BDC-A38C-480F-B227-38FCAB69D949}"), StageId = Guid.Parse("{B003080E-2752-4B5A-ABF3-D2DA565EE750}"), UserId = Guid.Parse("08dded4a-1f34-4190-86c3-bf1dc04eff50"), IsMandatory = true, DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName }
                );
        }
    }
}
