using MC.Domain.Entity.Enum.Registration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Features.Registration.BankAccount.Command.Create
{
    public class CreateBankAccountCmd : IRequest<Guid>
    {
        public Guid UserProfileId { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string IFSCCode { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public AccountType AccountType { get; set; }
        public bool IsPassbookAvailable { get; set; } = false;
        public string? PassbookUrl { get; set; }
    }
}
