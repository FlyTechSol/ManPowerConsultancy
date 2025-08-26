using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Menu
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MC.Domain.Entity.Menu.MenuItem>
    {
        public void Configure(EntityTypeBuilder<MC.Domain.Entity.Menu.MenuItem> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Title).HasMaxLength(100);
            builder.Property(z => z.Url).HasMaxLength(256);
            builder.Property(z => z.IconUrl).HasMaxLength(100);
        }
    }
}
