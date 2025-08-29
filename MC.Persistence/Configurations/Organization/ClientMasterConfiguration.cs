using MC.Domain.Entity.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Organization
{
    public class ClientMasterConfiguration : IEntityTypeConfiguration<ClientMaster>
    {
        public void Configure(EntityTypeBuilder<ClientMaster> builder)
        {
            builder.ConfigureAuditFields();

            builder.HasOne(c => c.Company)
                .WithMany(cmp => cmp.ClientMasters)
                .HasForeignKey(c => c.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(z => z.ClientName).IsRequired().HasMaxLength(100);
            builder.Property(z => z.ProjectStartDate).HasColumnType("date");
            builder.Property(z => z.ProjectEndDate).HasColumnType("date");
            builder.Property(b => b.ProjectCost).HasPrecision(18, 2);
            builder.Property(z => z.ProjectLocation).HasMaxLength(100);


            builder.HasData(
                new ClientMaster
                {
                    Id = Guid.Parse("{8A4A5A20-7236-46E4-9739-8AB7A47F554E}"),
                    CompanyId = Guid.Parse("{489D4544-5461-4132-AA29-688758627C98}"),
                    ClientName = "My First Company - Client master 1",
                    ProjectStartDate = new DateTime(2025, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                    ProjectEndDate = new DateTime(2026, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                    ProjectCost = 178956.00,
                    ProjectLocation = "Lucknow",
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new ClientMaster
                {
                    Id = Guid.Parse("{F6D29BE9-277A-423E-8213-DE2F866D5301}"),
                    CompanyId = Guid.Parse("489D4544-5461-4132-AA29-688758627C98"),
                    ClientName = "My First Company - Client master 2",
                    ProjectStartDate = new DateTime(2025, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                    ProjectEndDate = new DateTime(2026, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                    ProjectCost = 178956.00,
                    ProjectLocation = "Lucknow",
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new ClientMaster
                {
                    Id = Guid.Parse("{836BD5C1-C940-4900-9E49-FD6FEE2C80FA}"),
                    CompanyId = Guid.Parse("74C8B851-922F-45B9-9C28-0C53C06120AA"),
                    ClientName = "My Second Company - Client master 1",
                    ProjectStartDate = new DateTime(2025, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                    ProjectEndDate = new DateTime(2026, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                    ProjectCost = 178956.00,
                    ProjectLocation = "Lucknow",
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                }
            );
        }
    }
}
