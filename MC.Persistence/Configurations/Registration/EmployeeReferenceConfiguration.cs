using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class EmployeeReferenceConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.EmployeeReference>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.EmployeeReference> builder)
        {
            builder.Property(z => z.EmployeeName).IsRequired().HasMaxLength(100);
            builder.Property(z => z.EmployeeDesignation).HasMaxLength(80);
            builder.Property(z => z.EmployeeDepartment).HasMaxLength(80);
            builder.Property(z => z.EmployeeContactNumber).HasMaxLength(15);
            builder.Property(z => z.EmployeeEmail).HasMaxLength(100);
            builder.Property(z => z.EmployeeAddress).HasMaxLength(200);
            builder.Property(z => z.EmployeeRelationship).HasMaxLength(50);
            builder.Property(z => z.Remarks).HasMaxLength(200);
            builder.Property(z => z.IsActive).HasDefaultValue(true);

            // User relationship
            builder.HasOne(b => b.UserProfile)
               .WithMany(u => u.EmployeeReferences)
               .HasForeignKey(b => b.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
