using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MC.Persistence.Configurations.Menu
{
    public class MenuConfiguration : IEntityTypeConfiguration<MC.Domain.Entity.Menu.Menu>
    {
        public void Configure(EntityTypeBuilder<MC.Domain.Entity.Menu.Menu> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.Title).HasMaxLength(100);
            //builder.Property(z => z.NavigationURL).HasMaxLength(256);
            builder.Property(z => z.IconUrl).HasMaxLength(100);

            // Relationship: One Menu -> Many MenuItems
            builder.HasMany(m => m.MenuItems)
                   .WithOne(mi => mi.Menu)
                   .HasForeignKey(mi => mi.MenuId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
