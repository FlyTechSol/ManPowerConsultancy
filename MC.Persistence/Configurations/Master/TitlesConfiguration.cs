using MC.Domain.Entity.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Master
{
    public class TitlesConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Code).IsRequired().HasMaxLength(10);
            builder.Property(z => z.Name).IsRequired().HasMaxLength(10);
            builder.Property(z => z.DisplayOrder).IsRequired();

            builder.HasData(
                new Title
                {
                    Id = Guid.Parse("{AD77F3F7-CF8A-4F72-A38D-F9AAADE1D79F}"),
                    Code = "Mr",
                    Name = "Mr",
                    IsFemale = false,
                    IsMale = true,
                    DisplayOrder = 1,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                },
                new Title
                {
                    Id = Guid.Parse("{E38E5FB5-5339-46B9-B108-DF23F286A5F4}"),
                    Code = "Mrs",
                    Name = "Mrs",
                    IsFemale = true,
                    IsMale = false,
                    DisplayOrder = 2,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                },
                new Title
                {
                    Id = Guid.Parse("{38A86421-EDB4-4226-8E95-423F65785280}"),
                    Code = "Miss",
                    Name = "Miss",
                    IsFemale = true,
                    IsMale = false,
                    DisplayOrder = 3,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                },
                new Title
                {
                    Id = Guid.Parse("{93EE9668-462F-437E-BF20-84BEF4C38428}"),
                    Code = "Ms",
                    Name = "Ms",
                    IsFemale = true,
                    IsMale = false,
                    DisplayOrder = 4,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                },
                new Title
                {
                    Id = Guid.Parse("{2673EA56-221C-433E-9A54-A2740615F9AB}"),
                    Code = "Dr",
                    Name = "Dr",
                    IsFemale = true,
                    IsMale = false,
                    DisplayOrder = 5,
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
