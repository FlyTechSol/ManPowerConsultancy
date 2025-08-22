using MC.Domain.Entity.Enum.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Command.Update
{
    public class UpdateBankAccountCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string IFSCCode { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public AccountType AccountType { get; set; }
        public bool IsPassbookAvailable { get; set; } = false;
        public string? PassbookUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
