
namespace MC.Domain.Entity.Registration
{
    //for auto registration id generation, not derived from audit table
    public class RegistrationSequence
    {
        public int Id { get; set; } // start with 100
        public int LastRegistrationId { get; set; }
    }
}
