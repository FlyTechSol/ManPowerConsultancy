using Microsoft.AspNetCore.Identity;

namespace MC.Domain.Entity.Identity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole() : base() { }
        public int DisplayOrder { get; set; }
    }
}
