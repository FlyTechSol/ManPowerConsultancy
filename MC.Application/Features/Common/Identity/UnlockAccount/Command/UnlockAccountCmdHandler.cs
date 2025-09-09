using MC.Application.Contracts.Identity;
using MediatR;

namespace MC.Application.Features.Common.Identity.UnlockAccount.Command
{
    public class UnlockAccountCmdHandler : IRequestHandler<UnlockAccountCmd, bool>
    {
        private readonly IIdentityService _identityService;

        public UnlockAccountCmdHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<bool> Handle(UnlockAccountCmd request, CancellationToken cancellationToken)
        {
            return await _identityService.UnlockUserByEmailAsync(request.Email);
        }
    }
}
