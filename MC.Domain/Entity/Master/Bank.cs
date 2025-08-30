using MC.Domain.Base;
using MC.Domain.Entity.Registration;

namespace MC.Domain.Entity.Master
{
    public class Bank : BaseEntity
    {
        public string Code { get; set; } = string.Empty; // Code for the caste category
        public string Name { get; set; } = string.Empty; // Description of the caste category
        public int? DisplayOrder { get; set; } // Order of the level, used for sorting

        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
    }
}
