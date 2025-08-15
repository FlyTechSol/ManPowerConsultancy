using MC.Domain.Entity.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Persistence.Configurations
{
    public class GendersConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasData(
                new Gender
                {
                    Id = Guid.Parse("{36347864-631A-4F09-A62E-F090A3A5CC5B}"),
                    DisplayOrder = 1,
                    Code = "M",
                    Decode = "Male",
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                },
                new Gender
                {
                    Id = Guid.Parse("{D98D9544-7AE7-43DE-AB11-3DC7A46B4A0E}"),
                    DisplayOrder = 2,
                    Code = "F",
                    Decode = "Female",
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    ModifiedByUserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
                }
            );

            builder.Property(q => q.Code)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(q => q.Decode)
               .IsRequired()
               .HasMaxLength(100);
        }
    }
}
