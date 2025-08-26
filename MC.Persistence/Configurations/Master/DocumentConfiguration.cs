using MC.Domain.Entity.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Master
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.DocumentName).IsRequired().HasMaxLength(100);
            builder.Property(z => z.Description).HasMaxLength(200);

            builder.HasData(
                new Document
                {
                    Id = Guid.Parse("CE952EC2-D4C4-4BF6-B0DE-EA441DAC9206"),
                    DocumentName = "Aadhaar",
                    Description = "Issued by Govt. Of India",
                    IsIdentityProof = true,
                    IsAddressProof = true,
                    IsAgeProof = false,
                    IsQualificationProof = false,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new Document
                {
                    Id = Guid.Parse("6FB4A203-871A-49B6-9B8E-DDCD73B6F98A"),
                    DocumentName = "Driving License",
                    Description = "Issued by Govt. Of India",
                    IsIdentityProof = true,
                    IsAddressProof = true,
                    IsAgeProof = true,
                    IsQualificationProof = false,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new Document
                {
                    Id = Guid.Parse("103B1E73-C652-458E-AD5F-9EA868D7E3E9"),
                    DocumentName = "High School Certificat/Marksheet",
                    Description = "High School Certificat/Marksheet",
                    IsIdentityProof = false,
                    IsAddressProof = false,
                    IsAgeProof = true,
                    IsQualificationProof = true,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                }
                );
        }
    }
}
