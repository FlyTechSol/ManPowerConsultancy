using MC.Domain.Base;
using MC.Domain.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Domain.Entity.Registration
{
    public class Address : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } // Navigation property to AspNetUsers
        public string C_AddressLine1 { get; set; } = string.Empty;
        public string C_AddressLine2 { get; set; } = string.Empty;
        public string C_PinCode { get; set; } = string.Empty;
        public string C_City { get; set; } = string.Empty;
        public string C_District { get; set; } = string.Empty;
        public string C_State { get; set; } = string.Empty;
        public string C_Country { get; set; } = string.Empty;
        public bool IsPermanentAddressSame { get; set; }
        public string P_AddressLine1 { get; set; } = string.Empty;
        public string P_AddressLine2 { get; set; } = string.Empty;
        public string P_PinCode { get; set; } = string.Empty;
        public string P_City { get; set; } = string.Empty;
        public string P_District { get; set; } = string.Empty;
        public string P_State { get; set; } = string.Empty;
        public string P_Country { get; set; } = string.Empty;
    }
}
