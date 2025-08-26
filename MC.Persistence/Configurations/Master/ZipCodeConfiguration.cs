using MC.Domain.Entity.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Master
{
    public class ZipCodeConfiguration : IEntityTypeConfiguration<ZipCode>
    {
        public void Configure(EntityTypeBuilder<ZipCode> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Zipcode).HasMaxLength(10);
            builder.Property(z => z.City).HasMaxLength(100);
            builder.Property(z => z.District).HasMaxLength(100);
            builder.Property(z => z.State).HasMaxLength(100);
            builder.Property(z => z.Country).HasMaxLength(100);
        }
    }
}
