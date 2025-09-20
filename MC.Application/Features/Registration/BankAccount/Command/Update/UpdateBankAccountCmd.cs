using MC.Domain.Entity.Enum.Registration;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MC.Application.Features.Registration.BankAccount.Command.Update
{
    public class UpdateBankAccountCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public Guid BankId { get; set; }
        public string IFSCCode { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public AccountType AccountType { get; set; }
        public bool IsPassbookAvailable { get; set; } = false;
        public IFormFile? PassbookUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
