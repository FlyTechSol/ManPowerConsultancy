using MC.Domain.Entity.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Organization
{
    public class ClientUnitConfiguration : IEntityTypeConfiguration<ClientUnit>
    {
        public void Configure(EntityTypeBuilder<ClientUnit> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.UnitName).HasMaxLength(100);
            builder.Property(z => z.ClientMasterId).IsRequired();

            builder.HasIndex(z => z.ClientMasterId);

            builder.HasOne(c => c.ClientMaster)
               .WithMany(cmp => cmp.Units)
               .HasForeignKey(c => c.ClientMasterId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new ClientUnit
                {
                    Id = Guid.Parse("{2654AB1A-DC1D-4B93-9249-9CD4F9228968}"),
                    ClientMasterId = Guid.Parse("8A4A5A20-7236-46E4-9739-8AB7A47F554E"),
                    UnitName = "My first unit",
                    UnitLocation = "Kanpur",
                    MaxHeadCount = 15,
                    IsActive =true,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new ClientUnit
                {
                    Id = Guid.Parse("{F1A7C96C-D787-488D-8C04-22E3AAAC0CEE}"),
                    ClientMasterId = Guid.Parse("8A4A5A20-7236-46E4-9739-8AB7A47F554E"),
                    UnitName = "My 2nd unit",
                    UnitLocation = "Lakhimpur",
                    MaxHeadCount = 0,
                    IsActive = true,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new ClientUnit
                {
                    Id = Guid.Parse("{B7ED692B-63FC-441F-8748-0F10672D9E8D}"),
                    ClientMasterId = Guid.Parse("F6D29BE9-277A-423E-8213-DE2F866D5301"),
                    UnitName = "My 3rd unit",
                    UnitLocation = "Unnao",
                    MaxHeadCount = 30,
                    IsActive = true,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new ClientUnit
                {
                    Id = Guid.Parse("{61054527-D93F-4C43-AC91-D869A6428327}"),
                    ClientMasterId = Guid.Parse("836BD5C1-C940-4900-9E49-FD6FEE2C80FA"),
                    UnitName = "My 4th unit",
                    UnitLocation = "Agra",
                    MaxHeadCount = 10,
                    IsActive = true,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                }
            );
        }
    }
}
