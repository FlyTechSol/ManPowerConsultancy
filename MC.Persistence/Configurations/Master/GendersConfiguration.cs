using MC.Domain.Entity.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Master
{
    public class GendersConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Code).IsRequired().HasMaxLength(10);
            builder.Property(z => z.Name).IsRequired().HasMaxLength(50);
            builder.Property(z => z.DisplayOrder).IsRequired();
            builder.HasIndex(z => z.Code).IsUnique();

            builder.HasData(
                new Gender
                {
                    Id = Guid.Parse("{36347864-631A-4F09-A62E-F090A3A5CC5B}"),
                    Code = "M",
                    Name = "Male",
                    DisplayOrder = 1,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                },
                new Gender
                {
                    Id = Guid.Parse("{D98D9544-7AE7-43DE-AB11-3DC7A46B4A0E}"),
                    Code = "F",
                    Name = "Female",
                    DisplayOrder = 2,
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
