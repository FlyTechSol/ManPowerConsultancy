using MC.Domain.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<Domain.Entity.Registration.BankAccount>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Registration.BankAccount> builder)
        {
            builder.ConfigureAuditFields();

            builder.Property(z => z.BankName).HasMaxLength(100);
            builder.Property(z => z.IFSCCode).HasMaxLength(15);
            builder.Property(z => z.AccountNo).HasMaxLength(20);
            builder.Property(z => z.PassbookUrl).HasMaxLength(256);

            // Enum: store as string
            builder.Property(b => b.AccountType)
                   .HasConversion<string>()
                   .HasMaxLength(20);

            builder.HasOne(b => b.UserProfile)
               .WithMany(u => u.BankAccounts)
               .HasForeignKey(b => b.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
