using MC.Domain.Entity.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Organization
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.CompanyName).HasMaxLength(100);
            builder.Property(z => z.LegalName).HasMaxLength(100);
            builder.Property(z => z.RegistrationNumber).HasMaxLength(25);
            builder.Property(z => z.CompanyPan).HasMaxLength(10);
            builder.Property(z => z.Email).HasMaxLength(70);
            builder.Property(z => z.Phone).HasMaxLength(15);
            builder.Property(z => z.Website).HasMaxLength(256);
            builder.Property(z => z.AddressLine1).HasMaxLength(100);
            builder.Property(z => z.AddressLine2).HasMaxLength(100);
            builder.Property(z => z.City).HasMaxLength(100);
            builder.Property(z => z.State).HasMaxLength(100);
            builder.Property(z => z.Country).HasMaxLength(100);
            builder.Property(z => z.ZipCode).HasMaxLength(10);

          
            builder.HasData(
                new Company
                {
                    Id = Guid.Parse("{489D4544-5461-4132-AA29-688758627C98}"),
                    CompanyName = "My First Company",
                    LegalName = "My First Company Pvt Ltd",
                    RegistrationNumber = "1234567890",
                    CompanyPan = "ABCDE1234F",
                    Email = "test@test.com",
                    Phone = "1234567890",
                    Website = "https://www.test.com",
                    AddressLine1 = "address line 1",
                    AddressLine2 = "address line 2",
                    City = "Lucknow",
                    State = "Uttar Pradesh",
                    Country = "India",
                    ZipCode = "123456",
                    IsActive = true,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new Company
                {
                    Id = Guid.Parse("{74C8B851-922F-45B9-9C28-0C53C06120AA}"),
                    CompanyName = "My Second Company",
                    LegalName = "My Second Company Pvt Ltd",
                    RegistrationNumber = "1234567890",
                    CompanyPan = "ABCDE1234F",
                    Email = "test@test.com",
                    Phone = "1234567890",
                    Website = "https://www.test.com",
                    AddressLine1 = "address line 1",
                    AddressLine2 = "address line 2",
                    City = "Lucknow",
                    State = "Uttar Pradesh",
                    Country = "India",
                    ZipCode = "123456",
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
