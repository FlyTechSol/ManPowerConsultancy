
using MC.Domain.Entity.Organization;

namespace MC.Domain.Entity.Registration
{
    //for auto registration id generation, not derived from audit table
    public class RegistrationSequence
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;
        public int LastRegistrationId { get; set; }
        public string Prefix { get; set; } = string.Empty;
    }
}
