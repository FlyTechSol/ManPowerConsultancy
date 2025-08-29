using MC.Domain.Entity.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Master
{
    public class BankConfigiration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Code).HasMaxLength(50);
            builder.Property(z => z.Name).HasMaxLength(70);
            builder.Property(z => z.DisplayOrder).IsRequired();
            builder.HasIndex(z => z.Code).IsUnique();

        }
    }
}
