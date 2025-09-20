using MC.Domain.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class UserDocumentConfiguration : IEntityTypeConfiguration<UserDocument>
    {
        public void Configure(EntityTypeBuilder<UserDocument> builder)
        {
            builder.Property(x => x.FilePath)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.HasOne(x => x.UserProfile)
                   .WithMany(u => u.UserDocuments)
                   .HasForeignKey(x => x.UserProfileId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.DocumentType)
                   .WithMany(d => d.UserDocuments)
                   .HasForeignKey(x => x.DocumentTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
