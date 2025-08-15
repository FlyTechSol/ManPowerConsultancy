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
    public class TitlesConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.HasData(
                new Title
                {
                    Id = Guid.Parse("{AD77F3F7-CF8A-4F72-A38D-F9AAADE1D79F}"),
                    DisplayOrder = 1,
                    Code = "Mr",
                    Decode = "Mr",
                    IsFemale = false,
                    IsMale = true,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Title
                {
                    Id = Guid.Parse("{E38E5FB5-5339-46B9-B108-DF23F286A5F4}"),
                    DisplayOrder = 2,
                    Code = "Mrs",
                    Decode = "Mrs",
                    IsFemale = true,
                    IsMale = false,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc)
                }
                ,
                new Title
                {
                    Id = Guid.Parse("{38A86421-EDB4-4226-8E95-423F65785280}"),
                    DisplayOrder = 3,
                    Code = "Miss",
                    Decode = "Miss",
                    IsFemale = true,
                    IsMale = false,
                    DateCreated = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc),
                    DateModified = new DateTime(2025, 8, 1, 0, 0, 0, DateTimeKind.Utc)
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
