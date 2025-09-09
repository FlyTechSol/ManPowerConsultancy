using MediatR;

namespace MC.Application.Features.Common.Identity.UnlockAccount.Command
{
    public class UnlockAccountCmd : IRequest<bool>
    {
        public string Email { get; set; } = string.Empty;
    }
}
