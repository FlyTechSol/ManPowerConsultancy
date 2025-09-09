using MC.Application.Exceptions;
using MC.Domain.Entity.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MC.Application.Features.Common.Identity.ResetPassword.Command
{
    public class ResetPasswordCmdHandler : IRequestHandler<ResetPasswordCmd, Unit>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResetPasswordCmdHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(ResetPasswordCmd request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.Email);
            }

            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
            if (!result.Succeeded)
            {
                if (result.Errors.Any(e => e.Code == "InvalidToken"))
                {
                    throw new ValidationException("The reset token is invalid or has expired.");
                }
                else
                {
                    throw new ValidationException("Error resetting password. Please try again.");
                }
            }

            return Unit.Value;
        }
    }
}
