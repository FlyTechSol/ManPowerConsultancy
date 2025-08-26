using MC.Domain.Entity.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Master
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Code).IsRequired().HasMaxLength(70);
            builder.Property(z => z.Name).IsRequired().HasMaxLength(70);
            builder.Property(z => z.DisplayOrder).IsRequired();
            builder.HasIndex(z => z.Code).IsUnique();

            Guid UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9");
            DateTime DateCreatedUtc = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc);

            builder.HasData(
                new Asset { Id = Guid.Parse("7F94266B-59C9-4414-AD04-DBA60100F74E"), DisplayOrder = 1, Code = "Adapter", Name = "Adapter", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000001"), DisplayOrder = 2, Code = "All In One Desktop", Name = "All In One Desktop", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000002"), DisplayOrder = 3, Code = "Bluetooth Wireless Mouse", Name = "Bluetooth Wireless Mouse", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000003"), DisplayOrder = 4, Code = "Combo Keyboard Mouse", Name = "Combo Keyboard Mouse", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000004"), DisplayOrder = 5, Code = "Desktop", Name = "Desktop", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000005"), DisplayOrder = 6, Code = "External Hard Disk", Name = "External Hard Disk", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000006"), DisplayOrder = 7, Code = "Hard Disk", Name = "Hard Disk", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000007"), DisplayOrder = 8, Code = "Keyboard", Name = "Keyboard", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000008"), DisplayOrder = 9, Code = "Keys", Name = "Keys", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000009"), DisplayOrder = 10, Code = "Laptop", Name = "Laptop", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF00000A"), DisplayOrder = 11, Code = "Laptop Bag", Name = "Laptop Bag", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF00000B"), DisplayOrder = 12, Code = "Legal Documents", Name = "Legal Documents", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF00000C"), DisplayOrder = 13, Code = "Mobile", Name = "Mobile", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF00000D"), DisplayOrder = 14, Code = "Monitor", Name = "Monitor", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF00000E"), DisplayOrder = 15, Code = "Mouse", Name = "Mouse", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF00000F"), DisplayOrder = 16, Code = "Mouse Paid", Name = "Mouse Paid", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000010"), DisplayOrder = 17, Code = "Pen Drive", Name = "Pen Drive", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000011"), DisplayOrder = 18, Code = "Petro Card", Name = "Petro Card", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000012"), DisplayOrder = 19, Code = "Portable Wi Fi", Name = "Portable Wi Fi", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000013"), DisplayOrder = 20, Code = "Projector", Name = "Projector", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000014"), DisplayOrder = 21, Code = "Rack", Name = "Rack", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000015"), DisplayOrder = 22, Code = "Registers", Name = "Registers", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000016"), DisplayOrder = 23, Code = "Samsung Tab (T295)", Name = "Samsung Tab (T295)", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000017"), DisplayOrder = 24, Code = "Apple Tab", Name = "Apple Tab", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000018"), DisplayOrder = 25, Code = "Sim Card", Name = "Sim Card", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000019"), DisplayOrder = 26, Code = "Sound Speaker", Name = "Sound Speaker", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF00001A"), DisplayOrder = 27, Code = "Stationary", Name = "Stationary", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF00001B"), DisplayOrder = 28, Code = "Type-C To Lan Adapter", Name = "Type-C To Lan Adapter", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF00001C"), DisplayOrder = 29, Code = "Type-C USB Hub", Name = "Type-C USB Hub", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF00001D"), DisplayOrder = 30, Code = "UPS", Name = "UPS", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF00001E"), DisplayOrder = 31, Code = "USB To Lan Connector", Name = "USB To Lan Connector", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF00001F"), DisplayOrder = 32, Code = "USB Wifi", Name = "USB Wifi", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000020"), DisplayOrder = 33, Code = "Vehicle", Name = "Vehicle", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000021"), DisplayOrder = 34, Code = "Web-Cam", Name = "Web-Cam", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000022"), DisplayOrder = 35, Code = "Wifi Router", Name = "Wifi Router", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId },
                new Asset { Id = Guid.Parse("A1B2C3D4-E5F6-4711-8899-ABCDEF000023"), DisplayOrder = 36, Code = "Wireless Mouse", Name = "Wireless Mouse", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId }
        );
        }
    }
}
