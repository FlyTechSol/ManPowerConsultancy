using MC.Domain.Entity.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Master
{
    public class CasteCategoryConfiguration : IEntityTypeConfiguration<CasteCategory>
    {
        public void Configure(EntityTypeBuilder<CasteCategory> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Code).HasMaxLength(10);
            builder.Property(z => z.Name).HasMaxLength(50);
            builder.Property(z => z.DisplayOrder).IsRequired();
            //builder.HasIndex(z => z.Code).IsUnique();

            builder.HasData(
                new CasteCategory
                {
                    Id = Guid.Parse("{88DEAA1C-C775-4F23-A5BC-99D2DED0A482}"),
                    DisplayOrder = 1,
                    Code = "Gen",
                    Name = "General",
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                },
                new CasteCategory
                {
                    Id = Guid.Parse("{001A635E-D1AB-41C4-84AA-50C8B2AB5B69}"),
                    DisplayOrder = 2,
                    Code = "SC",
                    Name = "Scheduled Caste",
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                },
                new CasteCategory
                {
                    Id = Guid.Parse("{F513D877-2D3D-4499-96EF-45E4B21CB6F1}"),
                    DisplayOrder = 3,
                    Code = "ST",
                    Name = "Scheduled Tribe",
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                },
                new CasteCategory
                {
                    Id = Guid.Parse("{C41DDE3E-D44B-44E0-856C-7B5CB1BF2FC3}"),
                    DisplayOrder = 4,
                    Code = "OBC",
                    Name = "Other Backward Classes",
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
