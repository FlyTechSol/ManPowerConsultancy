using MC.Domain.Base;
using MC.Domain.Entity.Enum.Registration;

namespace MC.Domain.Entity.Registration
{
    public class BankAccount : BaseEntity
    {
        public Guid UserProfileId { get; set; }
        public required UserProfile UserProfile { get; set; } // Navigation property to AspNetUsers
        public string BankName { get; set; } = string.Empty;
        public string IFSCCode { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public AccountType AccountType { get; set; } 
        public bool IsPassbookAvailable { get; set; } = false;
        public string? PassbookUrl { get; set; }
        public bool IsActive { get; set; } = true; // Indicates if the bank account is currently active
    }
}
