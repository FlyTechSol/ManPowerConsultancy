using MC.Domain.Entity.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MC.Persistence.Configurations.Registration
{
    public class RegistrationSequenceConfiguration : IEntityTypeConfiguration<RegistrationSequence>
    {
        public void Configure(EntityTypeBuilder<RegistrationSequence> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(
                new RegistrationSequence
                {
                    Id = 1,
                    LastRegistrationId = 100
                }
                );
        }
    }
}
