using MC.Domain.Base;

namespace MC.Domain.Entity.Organization
{
    //for auto registration id generation, not derived from audit table
    public class RegistrationSequence : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;
        public int LastRegistrationId { get; set; }
        public string Prefix { get; set; } = string.Empty;
    }
}
