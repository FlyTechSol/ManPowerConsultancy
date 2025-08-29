using MC.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations
{
    public static class EntityTypeBuilderExtensions
    {
        public static void ConfigureAuditFields<TEntity>(
            this EntityTypeBuilder<TEntity> builder)
            where TEntity : BaseEntity
        {
            builder.Property(e => e.CreatedByUserName)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(e => e.ModifiedByUserName)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.HasOne(e => e.CreatedByUser)
                .WithMany()
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.ModifiedByUser)
                .WithMany()
                .HasForeignKey(e => e.ModifiedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
