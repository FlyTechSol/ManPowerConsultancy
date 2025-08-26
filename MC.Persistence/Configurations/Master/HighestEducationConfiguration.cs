using MC.Domain.Entity.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Master
{
    public class HighestEducationConfiguration : IEntityTypeConfiguration<HighestEducation>
    {
        public void Configure(EntityTypeBuilder<HighestEducation> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Code).HasMaxLength(10);
            builder.Property(z => z.Name).HasMaxLength(50);
            builder.Property(z => z.DisplayOrder).IsRequired();
            builder.HasIndex(z => z.Code).IsUnique();

            builder.HasData(
                new HighestEducation
                {
                    Id = Guid.Parse("{B0724662-F36F-4BE6-9FC1-0122AE89B634}"),
                    Code = "BM",
                    Name = "Below Matric",
                    DisplayOrder = 1,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new HighestEducation
                {
                    Id = Guid.Parse("{5606CE88-EFBF-4406-8CFD-EE2AAB75A76D}"),
                    Code = "M",
                    Name = "Matric",
                    DisplayOrder = 2,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new HighestEducation
                {
                    Id = Guid.Parse("{A6AA659E-23D5-4A4F-9030-4FF36A3A8D05}"),
                    Code = "AM",
                    Name = "Above Matric",
                    DisplayOrder = 3,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new HighestEducation
                {
                    Id = Guid.Parse("{912CF56B-E42E-4297-86A8-8B7C6C1FDD6A}"),
                    Code = "UG",
                    Name = "Under Graduate",
                    DisplayOrder = 4,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new HighestEducation
                {
                    Id = Guid.Parse("{5E039E37-DC5F-48CC-8DCA-17A82174D779}"),
                    Code = "G",
                    Name = "Graduate",
                    DisplayOrder = 5,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new HighestEducation
                {
                    Id = Guid.Parse("{1FD20A85-E0AE-4EFD-91A8-E097C043E30D}"),
                    Code = "PG",
                    Name = "Post Graduate",
                    DisplayOrder = 6,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                }
            );
        }
    }
}
