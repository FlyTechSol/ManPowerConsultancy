using MC.Domain.Entity.Enum.Common;
using MC.Domain.Entity.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Master
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Name).IsRequired().HasMaxLength(50);
            builder.Property(z => z.Description).HasMaxLength(200);

            builder.HasData(
                new DocumentType
                {
                    Id = Guid.Parse("{295324BC-6EF8-4D98-AA9D-C94BDBBD2259}"),
                    Name = "Aadhaar Card",
                    Description = "Issued by Govt. Of India",
                    Purpose = DocumentPurpose.Identity | DocumentPurpose.Address | DocumentPurpose.Age,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                },
                 new DocumentType
                 {
                     Id = Guid.Parse("{6E7487B3-2D2C-40EE-AD2E-416798D790DD}"),
                     Name = "PAN Card",
                     Description = "Issued by Govt. Of India",
                     Purpose = DocumentPurpose.Identity,
                     DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                     DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                     CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                     ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                     CreatedByUserName = "System Admin",
                     ModifiedByUserName = "System Admin"
                 },
                 new DocumentType
                 {
                     Id = Guid.Parse("{45326A21-127B-4095-BF23-D96D8F11D43C}"),
                     Name = "10th Marksheet",
                     Description = "Issued by Govt. Of India",
                     Purpose = DocumentPurpose.Age | DocumentPurpose.Qualification,
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
