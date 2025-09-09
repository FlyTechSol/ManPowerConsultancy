using MC.Application.Contracts.Identity;
using MediatR;

namespace MC.Application.Features.Common.Identity.ChangePassword.Command
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCmd, bool>
    {
        private readonly IIdentityService _identityService;

        public ChangePasswordCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<bool> Handle(ChangePasswordCmd request, CancellationToken cancellationToken)
        {
            return await _identityService.ChangePasswordAsync(request.UserId, request.CurrentPassword, request.NewPassword);
        }
    }
}
