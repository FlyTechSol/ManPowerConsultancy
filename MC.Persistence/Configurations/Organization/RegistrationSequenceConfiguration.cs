using MC.Domain.Entity.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Organization
{
    public class RegistrationSequenceConfiguration : IEntityTypeConfiguration<RegistrationSequence>
    {
        public void Configure(EntityTypeBuilder<RegistrationSequence> builder)
        {
            builder.HasKey(rs => rs.CompanyId);

            builder.HasOne(rs => rs.Company)
                .WithOne(c => c.RegistrationSequence)
                .HasForeignKey<RegistrationSequence>(rs => rs.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(rs => rs.Prefix)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(rs => rs.LastRegistrationId)
                .IsRequired();

            // Optional: Seeding a company-specific starting value (example only)
            builder.HasData(
                new RegistrationSequence
                {
                    CompanyId = Guid.Parse("489D4544-5461-4132-AA29-688758627C98"),
                    LastRegistrationId = 100,
                    Prefix = "MFC"
                },
                new RegistrationSequence
                {
                    CompanyId = Guid.Parse("74C8B851-922F-45B9-9C28-0C53C06120AA"),
                    LastRegistrationId = 1000,
                    Prefix = "MSO"
                }
            );
        }
    }
}
