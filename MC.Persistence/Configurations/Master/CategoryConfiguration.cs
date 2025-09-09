using MC.Domain.Entity.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Master
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Code).IsRequired().HasMaxLength(50);
            builder.Property(z => z.Name).IsRequired().HasMaxLength(50);
            builder.Property(z => z.DisplayOrder).IsRequired();
            //builder.HasIndex(z => z.Code).IsUnique();

            builder.HasData(
                new Category
                {
                    Id = Guid.Parse("{25082EC5-82BF-4D5C-86F6-42F50AFF16A6}"),
                    Code = "Staff",
                    Name = "Staff",
                    DisplayOrder = 1,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                },
                new Category
                {
                    Id = Guid.Parse("{E5663953-E560-4582-AFBF-95D99777C299}"),
                    Code = "Guard",
                    Name = "Guard",
                    DisplayOrder = 2,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    CreatedByUserName = "System Admin",
                    ModifiedByUserName = "System Admin"
                },
                new Category
                {
                    Id = Guid.Parse("{3E91DF26-A6DB-47B4-91B8-4DD08F3529BB}"),
                    Code = "Facility",
                    Name = "Facility",
                    DisplayOrder = 3,
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
