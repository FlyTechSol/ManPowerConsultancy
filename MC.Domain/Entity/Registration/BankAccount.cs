using MC.Domain.Base;
using MC.Domain.Entity.Enum;
using MC.Domain.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Domain.Entity.Registration
{
    public class BankAccount : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } // Navigation property to AspNetUsers
        public string BankName { get; set; } = string.Empty;
        public string IFSCCode { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public AccountType AccountType { get; set; } 
        public bool IsPassBookAvailable { get; set; } = false;
    }
}
