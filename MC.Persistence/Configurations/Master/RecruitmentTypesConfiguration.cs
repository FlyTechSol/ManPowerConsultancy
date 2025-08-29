using MC.Domain.Entity.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace MC.Persistence.Configurations.Master
{
    public class RecruitmentTypesConfiguration : IEntityTypeConfiguration<RecruitmentType>
    {
        public void Configure(EntityTypeBuilder<RecruitmentType> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Code).HasMaxLength(10);
            builder.Property(z => z.Name).HasMaxLength(50);
            builder.Property(z => z.DisplayOrder).IsRequired();
            builder.HasIndex(z => z.Code).IsUnique();
            builder.HasData(
               new RecruitmentType
               {
                   Id = Guid.Parse("{568AB9C5-A0D3-441D-80E8-5A5651798324}"),
                   Code = "WI",
                   Name = "Walk -in",
                   DisplayOrder = 1,
                   DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                   DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                   CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                   ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                   CreatedByUserName = "System Admin",
                   ModifiedByUserName = "System Admin"
               },
               new RecruitmentType
               {
                   Id = Guid.Parse("{57B75925-449A-407E-8CC3-EBFF71EA3496}"),
                   Code = "R",
                   Name = "Referral",
                   DisplayOrder = 2,
                   DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                   DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                   CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                   ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                   CreatedByUserName = "System Admin",
                   ModifiedByUserName = "System Admin"
               },
               new RecruitmentType
               {
                   Id = Guid.Parse("{105B314F-DB6D-420F-B54E-1BB827E7754A}"),
                   Code = "RD",
                   Name = "Recruitment Drive",
                   DisplayOrder = 3,
                   DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                   DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                   CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                   ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                   CreatedByUserName = "System Admin",
                   ModifiedByUserName = "System Admin"
               },
               new RecruitmentType
               {
                   Id = Guid.Parse("{7F9A2901-E56C-4395-950D-A8A103F07DE5}"),
                   Code = "O",
                   Name = "Other",
                   DisplayOrder = 4,
                   DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                   DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                   CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                   ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                   CreatedByUserName = "System Admin",
                   ModifiedByUserName = "System Admin"
               }
           );
        }
    }
}
