using MC.Domain.Base;

namespace MC.Domain.Entity.Registration
{
    public class Resignation : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers
        public DateTime ResignationDate { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
