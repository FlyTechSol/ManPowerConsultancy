using MC.Domain.Entity.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Master
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Code).IsRequired().HasMaxLength(50);
            builder.Property(z => z.Name).IsRequired().HasMaxLength(50);
            builder.Property(z => z.DisplayOrder).IsRequired();
            //builder.HasIndex(z => z.Code).IsUnique();

            Guid UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9");
            DateTime DateCreatedUtc = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc);
            var UserName = "System Admin";
            builder.HasData(
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000001"), DisplayOrder = 1, Code = "ANDHRA PRADESH", Name = "ANDHRA PRADESH", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000002"), DisplayOrder = 2, Code = "ASSAM", Name = "ASSAM", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000003"), DisplayOrder = 3, Code = "BIHAR", Name = "BIHAR", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000004"), DisplayOrder = 4, Code = "CHHATTISHGARH", Name = "CHHATTISHGARH", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000005"), DisplayOrder = 5, Code = "CORPORATE OFFICE", Name = "CORPORATE OFFICE", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000006"), DisplayOrder = 6, Code = "DELHI", Name = "DELHI", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000007"), DisplayOrder = 7, Code = "GOA", Name = "GOA", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000008"), DisplayOrder = 8, Code = "GUJARAT", Name = "GUJARAT", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000009"), DisplayOrder = 9, Code = "HARYANA", Name = "HARYANA", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000010"), DisplayOrder = 10, Code = "HEAD OFFICE", Name = "HEAD OFFICE", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000011"), DisplayOrder = 11, Code = "HIMACHAL PRADESH", Name = "HIMACHAL PRADESH", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000012"), DisplayOrder = 12, Code = "JAMMU & KASHMIR", Name = "JAMMU & KASHMIR", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000013"), DisplayOrder = 13, Code = "JHARKHAND", Name = "JHARKHAND", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000014"), DisplayOrder = 14, Code = "KARNATAKA", Name = "KARNATAKA", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000015"), DisplayOrder = 15, Code = "KERALA", Name = "KERALA", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000016"), DisplayOrder = 16, Code = "MADHYA PRADESH", Name = "MADHYA PRADESH", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000017"), DisplayOrder = 17, Code = "MAHARASHTRA", Name = "MAHARASHTRA", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000018"), DisplayOrder = 18, Code = "NONE", Name = "NONE", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000019"), DisplayOrder = 19, Code = "NORTH EAST STATES", Name = "NORTH EAST STATES", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000020"), DisplayOrder = 20, Code = "ODISHA", Name = "ODISHA", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000021"), DisplayOrder = 21, Code = "PUNJAB", Name = "PUNJAB", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000022"), DisplayOrder = 22, Code = "RAJASTHAN", Name = "RAJASTHAN", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000023"), DisplayOrder = 23, Code = "TAMIL NADU", Name = "TAMIL NADU", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000024"), DisplayOrder = 24, Code = "TELANGANA", Name = "TELANGANA", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000025"), DisplayOrder = 25, Code = "UTTAR PRADESH", Name = "UTTAR PRADESH", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000026"), DisplayOrder = 26, Code = "UTTRAKHAND", Name = "UTTRAKHAND", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName },
                new Branch { Id = Guid.Parse("C1A1D1E1-F1A1-4711-8899-000000000027"), DisplayOrder = 27, Code = "WEST BENGAL", Name = "WEST BENGAL", DateCreated = DateCreatedUtc, DateModified = DateCreatedUtc, CreatedByUserId = UserId, ModifiedByUserId = UserId, CreatedByUserName = UserName, ModifiedByUserName = UserName }
            );
        }
    }
}
