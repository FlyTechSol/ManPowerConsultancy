using MC.Domain.Entity.Enum.Registration;

namespace MC.Application.ModelDto.Registration
{
    public class BankAccountDto
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public string UserProfileName { get; set; } = string.Empty;
        public Guid BankId { get; set; }
        public string BankName { get; set; } = null!;
        public string IFSCCode { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public AccountType AccountType { get; set; }
        public bool IsPassBookAvailable { get; set; } = false;
        public string? PassbookUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
