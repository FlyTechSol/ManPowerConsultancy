using MC.Domain.Entity.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Master
{
    public class ReligionConfiguration : IEntityTypeConfiguration<Religion>
    {
        public void Configure(EntityTypeBuilder<Religion> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Code).HasMaxLength(10);
            builder.Property(z => z.Name).HasMaxLength(50);
            builder.Property(z => z.DisplayOrder).IsRequired();
            builder.HasIndex(z => z.Code).IsUnique();

            //builder.HasData(
            //    new Religion
            //    {
            //        Id = new Guid("{02B89CCD-BE5B-4E47-9C8B-93124B61535D}"),
            //        DisplayOrder = 1,
            //        Code = "H",
            //        Name = "Hinduism",
            //        DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
            //        DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
            //        CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
            //        ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
            //    },
            //    new Religion
            //    {
            //        Id = new Guid("{6ECF09B0-EB25-4BA4-A63D-83034E696A2D}"),
            //        DisplayOrder = 2,
            //        Code = "M",
            //        Name = "Islam",
            //        DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
            //        DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
            //        CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
            //        ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
            //    },
            //    new Religion
            //    {
            //        Id = new Guid("{F3DC470A-389E-42A6-B9BF-3C3BFAAEBD81}"),
            //        DisplayOrder = 3,
            //        Code = "C",
            //        Name = "Christianity",
            //        DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
            //        DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
            //        CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
            //        ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
            //    },
            //    new Religion
            //    {
            //        Id = new Guid("{601B7C4F-7FC5-43D4-B21D-84FB748F2F19}"),
            //        DisplayOrder = 4,
            //        Code = "S",
            //        Name = "Sikhism",
            //        DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
            //        DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
            //        CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
            //        ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
            //    },
            //    new Religion
            //    {
            //        Id = new Guid("{2CE72C21-6F62-41C3-B1AD-B1D3647AE7F9}"),
            //        DisplayOrder = 5,
            //        Code = "B",
            //        Name = "Buddhism",
            //        DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
            //        DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
            //        CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
            //        ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
            //    },
            //    new Religion
            //    {
            //        Id = new Guid("{C1E0AF6A-C766-4102-A53A-96525ECF8DAE}"),
            //        DisplayOrder = 6,
            //        Code = "J",
            //        Name = "Jainism",
            //        DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
            //        DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
            //        CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
            //        ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
            //    },
            //    new Religion
            //    {
            //        Id = new Guid("{F10DD4EE-53CA-46A9-AB3D-5C1C54CFB16E}"),
            //        DisplayOrder = 7,
            //        Code = "Other",
            //        Name = "Other",
            //        DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
            //        DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
            //        CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
            //        ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
            //    }
            //);
        }
    }
}
